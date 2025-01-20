using BBB.NET.CORE.BigBlueButtonAPIClients;
using BBB.NET.CORE.DTOs;
using BBB.NET.CORE.Enums;
using BBB.NET.CORE.Helpers;
using BBB.NET.CORE.Requests.BreakoutRoom;
using BBB.NET.CORE.Responses.BreakoutRoom;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BBB.NET.CORE.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Produces("application/xml")]
    public class BreakoutRoomController : ControllerBase
    {
        private readonly BigBlueButtonAPIClient client;

        public BreakoutRoomController(BigBlueButtonAPIClient client)
        {
            this.client = client;
        }

        #region Create Breakout Rooms
        [HttpPost("create")]
        public async Task<IActionResult> CreateBreakoutRooms(
            [FromQuery] string parentMeetingID,
            [FromQuery] int roomCount,
            [FromQuery] int durationInMinutes,
            [FromQuery] string moderatorPW,
            [FromQuery] string attendeePW,
            [FromQuery] string name = "Breakout Room",
            [FromQuery] bool redirect = true,
            [FromBody] List<string> attendeeIDs = null)
        {
            try
            {
                if (string.IsNullOrEmpty(parentMeetingID) || roomCount <= 0)
                {
                    return BadRequest(XmlHelper.XmlErrorResponse<CreateBreakoutRoomsResponse>(
                        "Invalid input parameters.",
                        "Parent meeting ID and room count must be valid."));
                }

                var request = new CreateBreakoutRoomRequest
                {
                    ParentMeetingID = parentMeetingID,
                    RoomCount = roomCount,
                    DurationInMinutes = durationInMinutes,
                    ModeratorPW = moderatorPW,
                    AttendeePW = attendeePW,
                    Name = name,
                    Redirect = redirect,
                    AttendeeIDs = attendeeIDs ?? new List<string>()
                };

                var result = await client.CreateBreakoutRoomsAsync(request);

                if (result.returncode == Returncode.FAILED)
                {
                    return BadRequest(XmlHelper.XmlErrorResponse<CreateBreakoutRoomsResponse>(
                        "Failed to create breakout rooms.",
                        result.message));
                }

                return Ok(new CreateBreakoutRoomsResponse
                {
                    ParentMeetingID = parentMeetingID,
                    BreakoutRoomIDs = result.BreakoutRoomIDs,
                    message = "Breakout rooms created successfully."
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, XmlHelper.XmlErrorResponse<CreateBreakoutRoomsResponse>(
                    "An error occurred while creating breakout rooms.",
                    ex.Message));
            }
        }
        #endregion


        #region List Breakout Rooms
        [HttpGet("list")]
        public async Task<IActionResult> GetBreakoutRooms([FromQuery] string parentMeetingID)
        {
            try
            {
                if (string.IsNullOrEmpty(parentMeetingID))
                {
                    return BadRequest(XmlHelper.XmlErrorResponse<BreakoutRoomErrorResponseDto>(
                        "Parent meeting ID cannot be null or empty.",
                        "Invalid input."));
                }

                var result = await client.GetBreakoutRoomsAsync(new GetBreakoutRoomsRequest
                {
                    parentMeetingID = parentMeetingID
                });

                if (result.returncode == Returncode.FAILED)
                {
                    return BadRequest(XmlHelper.XmlErrorResponse<GetBreakoutRoomsResponse>(
                        "Failed to retrieve breakout rooms.",
                        result.message));
                }

                return Ok(XmlHelper.ToXml(new GetBreakoutRoomsResponse
                {
                    parentMeetingID = parentMeetingID,
                    breakoutRooms = result.breakoutRooms,
                    message = "Breakout rooms retrieved successfully."
                }));
            }
            catch (Exception ex)
            {
                return StatusCode(500, XmlHelper.XmlErrorResponse<GetBreakoutRoomsResponse>(
                    "An error occurred while retrieving breakout rooms.",
                    ex.Message));
            }
        }
        #endregion


        #region Join Breakout Room
        [HttpGet("join")]
        public async Task<IActionResult> JoinBreakoutRoom([FromQuery] JoinBreakoutRoomRequest request)
        {
            try
            {
                if (string.IsNullOrEmpty(request.breakoutRoomID))
                {
                    return BadRequest(XmlHelper.XmlErrorResponse<BreakoutRoomErrorResponseDto>(
                        "Breakout room ID cannot be null or empty.",
                        "Invalid input."));
                }

                var joinUrl = await client.GetJoinBreakoutRoomUrl(request);

                return Ok(XmlHelper.ToXml(new JoinBreakoutRoomResponse
                {
                    joinUrl = joinUrl,
                    Redirect = (bool)request.redirect,
                    message = "Join URL generated successfully."
                }));
            }
            catch (Exception ex)
            {
                return StatusCode(500, XmlHelper.XmlErrorResponse<JoinBreakoutRoomResponse>(
                    "An error occurred while generating join URL.",
                    ex.Message));
            }
        }
        #endregion


        #region End Breakout Room
        [HttpPost("end")]
        public async Task<IActionResult> EndBreakoutRoom([FromBody] EndBreakoutRoomRequest request)
        {
            try
            {
                if (string.IsNullOrEmpty(request.breakoutRoomID))
                {
                    return BadRequest(XmlHelper.XmlErrorResponse<BreakoutRoomErrorResponseDto>(
                        "Breakout room ID cannot be null or empty.",
                        "Invalid input."));
                }

                var result = await client.EndBreakoutRoomAsync(request);

                if (result.returncode == Returncode.FAILED)
                {
                    return BadRequest(XmlHelper.XmlErrorResponse<EndBreakoutRoomResponse>(
                        "Failed to end breakout room.",
                        result.message));
                }

                return Ok(XmlHelper.ToXml(new EndBreakoutRoomResponse
                {
                    breakoutRoomID = request.breakoutRoomID,
                    message = "Breakout room ended successfully."
                }));
            }
            catch (Exception ex)
            {
                return StatusCode(500, XmlHelper.XmlErrorResponse<EndBreakoutRoomResponse>(
                    "An error occurred while ending breakout room.",
                    ex.Message));
            }
        }
        #endregion


        #region Get Breakout Room Info
        [HttpGet("info")]
        public async Task<IActionResult> GetBreakoutRoomInfo([FromQuery] GetBreakoutRoomInfoRequest request)
        {
            try
            {
                if (string.IsNullOrEmpty(request.breakoutRoomID))
                {
                    return BadRequest(XmlHelper.XmlErrorResponse<BreakoutRoomErrorResponseDto>(
                        "Breakout room ID cannot be null or empty.",
                        "Invalid input."));
                }

                var result = await client.GetBreakoutRoomInfoAsync(request);

                if (result.returncode == Returncode.FAILED)
                {
                    return BadRequest(XmlHelper.XmlErrorResponse<GetBreakoutRoomInfoResponse>(
                        "Failed to retrieve breakout room info.",
                        result.message));
                }

                return Ok(XmlHelper.ToXml(new GetBreakoutRoomInfoResponse
                {
                    breakoutRoomID = request.breakoutRoomID,
                    meetingName = result.meetingName,
                    participantCount = result.participantCount,
                    duration = result.duration,
                    createTime = result.createTime,
                    message = "Breakout room info retrieved successfully."
                }));
            }
            catch (Exception ex)
            {
                return StatusCode(500, XmlHelper.XmlErrorResponse<GetBreakoutRoomInfoResponse>(
                    "An error occurred while retrieving breakout room info.",
                    ex.Message));
            }
        }
        #endregion


        #region Update Breakout Room
        [HttpPut("update")]
        public async Task<IActionResult> UpdateBreakoutRoom([FromBody] UpdateBreakoutRoomRequest request)
        {
            try
            {
                if (string.IsNullOrEmpty(request.breakoutRoomID))
                {
                    return BadRequest(XmlHelper.XmlErrorResponse<BreakoutRoomErrorResponseDto>(
                        "Breakout room ID cannot be null or empty.",
                        "Invalid input."));
                }

                var result = await client.UpdateBreakoutRoomAsync(request);

                if (result.returncode == Returncode.FAILED)
                {
                    return BadRequest(XmlHelper.XmlErrorResponse<UpdateBreakoutRoomResponse>(
                        "Failed to update breakout room.",
                        result.message));
                }

                return Ok(XmlHelper.ToXml(new UpdateBreakoutRoomResponse
                {
                    breakoutRoomID = request.breakoutRoomID,
                    message = "Breakout room updated successfully."
                }));
            }
            catch (Exception ex)
            {
                return StatusCode(500, XmlHelper.XmlErrorResponse<UpdateBreakoutRoomResponse>(
                    "An error occurred while updating breakout room.",
                    ex.Message));
            }
        }
        #endregion


        #region Delete Breakout Room
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteBreakoutRoom([FromQuery] DeleteBreakoutRoomRequest request)
        {
            try
            {
                if (string.IsNullOrEmpty(request.breakoutRoomID))
                {
                    return BadRequest(XmlHelper.XmlErrorResponse<BreakoutRoomErrorResponseDto>(
                        "Breakout room ID cannot be null or empty.",
                        "Invalid input."));
                }

                var result = await client.DeleteBreakoutRoomAsync(request);

                if (result.returncode == Returncode.FAILED)
                {
                    return BadRequest(XmlHelper.XmlErrorResponse<DeleteBreakoutRoomResponse>(
                        "Failed to delete breakout room.",
                        result.message));
                }

                return Ok(XmlHelper.ToXml(new DeleteBreakoutRoomResponse
                {
                    breakoutRoomID = request.breakoutRoomID,
                    message = "Breakout room deleted successfully."
                }));
            }
            catch (Exception ex)
            {
                return StatusCode(500, XmlHelper.XmlErrorResponse<DeleteBreakoutRoomResponse>(
                    "An error occurred while deleting breakout room.",
                    ex.Message));
            }
        }
        #endregion

    }
}
