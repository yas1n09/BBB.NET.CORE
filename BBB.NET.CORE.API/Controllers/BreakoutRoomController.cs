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
    [Route("api/[controller]")]
    [ApiController]
    public class BreakoutRoomController : ControllerBase
    {
        private readonly BigBlueButtonAPIClient client;

        public BreakoutRoomController(BigBlueButtonAPIClient client)
        {
            this.client = client;
        }

        #region Create Breakout Rooms
        [HttpPost("create")]
        [Produces("application/xml")]
        public async Task<IActionResult> CreateBreakoutRooms(string parentMeetingID, int roomCount, int durationInMinutes, string moderatorPW, string attendeePW, string name = "Breakout Room", bool redirect = true)
        {
            try
            {
                // Parametre doğrulama
                if (string.IsNullOrEmpty(parentMeetingID))
                {
                    return BadRequest(XmlHelper.XmlErrorResponse<CreateBreakoutRoomsResponse>(
                        "Parent meeting ID cannot be null or empty.",
                        "Invalid input."));
                }

                // API istemcisi için istek nesnesi oluşturma
                var request = new CreateBreakoutRoomRequest
                {
                    parentMeetingID = parentMeetingID,
                    roomCount = roomCount,
                    durationInMinutes = durationInMinutes,
                    moderatorPW = moderatorPW,
                    attendeePW = attendeePW,
                    name = name,
                    redirect = redirect
                };

                // Breakout odalarını oluşturmak için API çağrısı
                var result = await client.CreateBreakoutRoomsAsync(request);

                // Başarısız yanıt kontrolü
                if (result.returncode == Returncode.FAILED)
                {
                    return BadRequest(XmlHelper.XmlErrorResponse<CreateBreakoutRoomsResponse>(
                        "Failed to create breakout rooms.",
                        result.message));
                }

                // Başarılı yanıt oluşturma
                var response = new CreateBreakoutRoomsResponse
                {
                    parentMeetingID = parentMeetingID,
                    breakoutRoomIDs = result.breakoutRoomIDs,
                    message = "Breakout rooms created successfully."
                };

                return Ok(XmlHelper.ToXml(response));
            }
            catch (Exception ex)
            {
                // Hata yanıtı döndürme
                return StatusCode(500, XmlHelper.XmlErrorResponse<CreateBreakoutRoomsResponse>(
                    "An error occurred while creating breakout rooms.",
                    ex.Message));
            }
        }















        //public async Task<IActionResult> CreateBreakoutRooms(string parentMeetingID, int roomCount, int durationInMinutes, List<string> attendeeIDs, string moderatorPW, string attendeePW, string name = "Breakout Room", bool redirect = true)
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(parentMeetingID))
        //        {
        //            return BadRequest(XmlHelper.XmlErrorResponse<CreateBreakoutRoomsResponse>(
        //                "Parent meeting ID cannot be null or empty.",
        //                "Invalid input."));
        //        }

        //        var request = new CreateBreakoutRoomRequest
        //        {
        //            parentMeetingID = parentMeetingID,
        //            roomCount = roomCount,
        //            durationInMinutes = durationInMinutes,
        //            attendeeIDs = attendeeIDs,
        //            moderatorPW = moderatorPW,
        //            attendeePW = attendeePW,
        //            name = name,
        //            redirect = redirect
        //        };

        //        var result = await client.CreateBreakoutRoomsAsync(request);

        //        if (result.returncode == Returncode.FAILED)
        //        {
        //            return BadRequest(XmlHelper.XmlErrorResponse<CreateBreakoutRoomsResponse>(
        //                "Failed to create breakout rooms.",
        //                result.message));
        //        }

        //        var response = new CreateBreakoutRoomsResponse
        //        {
        //            parentMeetingID = parentMeetingID,
        //            breakoutRoomIDs = result.breakoutRoomIDs,
        //            message = "Breakout rooms created successfully."
        //        };

        //        return Ok(XmlHelper.ToXml(response));
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, XmlHelper.XmlErrorResponse<CreateBreakoutRoomsResponse>(
        //            "An error occurred while creating breakout rooms.",
        //            ex.Message));
        //    }
        //}



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



        //#region Create Breakout Rooms
        //[HttpPost("create")]
        //public async Task<IActionResult> CreateBreakoutRooms(string parentMeetingID, int roomCount, int durationInMinutes, List<string> attendeeIDs, string moderatorPW, string attendeePW, string namePrefix = "Breakout Room", bool redirect = true)
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(parentMeetingID))
        //        {
        //            return Content(XmlHelper.XmlErrorResponse<BreakoutRoomErrorResponseDto>(
        //                "Parent meeting ID cannot be null or empty.",
        //                "Invalid input."), "application/xml");
        //        }

        //        var request = new CreateBreakoutRoomRequest
        //        {
        //            parentMeetingID = parentMeetingID,
        //            roomCount = roomCount,
        //            durationInMinutes = durationInMinutes,
        //            attendeeIDs = attendeeIDs,
        //            moderatorPW = moderatorPW,
        //            attendeePW = attendeePW,
        //            name = namePrefix,
        //            redirect = redirect
        //        };

        //        var result = await client.CreateBreakoutRoomsAsync(request);

        //        if (result.returncode == Returncode.FAILED)
        //        {
        //            return Content(XmlHelper.XmlErrorResponse<CreateBreakoutRoomsResponse>(
        //                "Failed to create breakout rooms.",
        //                result.message), "application/xml");
        //        }

        //        return Content(XmlHelper.ToXml(new CreateBreakoutRoomsResponse
        //        {
        //            parentMeetingID = parentMeetingID,
        //            breakoutRoomIDs = result.breakoutRoomIDs,
        //            message = "Breakout rooms created successfully."
        //        }), "application/xml");
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, XmlHelper.XmlErrorResponse<CreateBreakoutRoomsResponse>(
        //            "An error occurred while creating breakout rooms.",
        //            ex.Message));
        //    }
        //}
        //#endregion


        //#region Create Breakout Rooms
        //[HttpPost("create")]
        //public async Task<IActionResult> CreateBreakoutRooms(string parentMeetingID, int roomCount, int durationInMinutes, List<string> attendeeIDs, string moderatorPW, string attendeePW, string namePrefix = "Breakout Room", bool redirect = true)
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(parentMeetingID))
        //        {
        //            return Content(XmlHelper.XmlErrorResponse<BreakoutRoomErrorResponseDto>(
        //                "Parent meeting ID cannot be null or empty.",
        //                "Invalid input."), "application/xml");
        //        }

        //        var request = new CreateBreakoutRoomRequest
        //        {
        //            parentMeetingID = parentMeetingID,
        //            roomCount = roomCount,
        //            durationInMinutes = durationInMinutes,
        //            attendeeIDs = attendeeIDs,
        //            moderatorPW = moderatorPW,
        //            attendeePW = attendeePW,
        //            name = namePrefix,
        //            redirect = redirect
        //        };

        //        var result = await client.CreateBreakoutRoomsAsync(request);

        //        if (result.returncode == Returncode.FAILED)
        //        {
        //            return Content(XmlHelper.XmlErrorResponse<CreateBreakoutRoomsResponse>(
        //                "Failed to create breakout rooms.",
        //                result.message), "application/xml");
        //        }

        //        return Content(XmlHelper.ToXml(new CreateBreakoutRoomsResponse
        //        {
        //            parentMeetingID = parentMeetingID,
        //            breakoutRoomIDs = result.breakoutRoomIDs,
        //            message = "Breakout rooms created successfully."
        //        }), "application/xml");
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, XmlHelper.XmlErrorResponse<CreateBreakoutRoomsResponse>(
        //            "An error occurred while creating breakout rooms.",
        //            ex.Message));
        //    }
        //}
        //#endregion

        //#region List Breakout Rooms
        //[HttpGet("list")]
        //public async Task<IActionResult> GetBreakoutRooms(string parentMeetingID)
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(parentMeetingID))
        //        {
        //            return Content(XmlHelper.XmlErrorResponse<BreakoutRoomErrorResponseDto>(
        //                "Parent meeting ID cannot be null or empty.",
        //                "Invalid input."), "application/xml");
        //        }

        //        var result = await client.GetBreakoutRoomsAsync(new GetBreakoutRoomsRequest
        //        {
        //            parentMeetingID = parentMeetingID
        //        });

        //        if (result.returncode == Returncode.FAILED)
        //        {
        //            return Content(XmlHelper.XmlErrorResponse<GetBreakoutRoomsResponse>(
        //                "Failed to retrieve breakout rooms.",
        //                result.message), "application/xml");
        //        }

        //        return Content(XmlHelper.ToXml(new GetBreakoutRoomsResponse
        //        {
        //            parentMeetingID = parentMeetingID,
        //            breakoutRooms = result.breakoutRooms,
        //            message = "Breakout rooms retrieved successfully."
        //        }), "application/xml");
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, XmlHelper.XmlErrorResponse<GetBreakoutRoomsResponse>(
        //            "An error occurred while retrieving breakout rooms.",
        //            ex.Message));
        //    }
        //}
        //#endregion

        //#region Join Breakout Room
        //[HttpGet("join")]
        //public async Task<IActionResult> JoinBreakoutRoom(string breakoutRoomID, string fullName, string password, bool redirect = true)
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(breakoutRoomID))
        //        {
        //            return Content(XmlHelper.XmlErrorResponse<BreakoutRoomErrorResponseDto>(
        //                "Breakout room ID cannot be null or empty.",
        //                "Invalid input."), "application/xml");
        //        }

        //        var joinUrl = await client.GetJoinBreakoutRoomUrl(new JoinBreakoutRoomRequest
        //        {
        //            breakoutRoomID = breakoutRoomID,
        //            fullName = fullName,
        //            password = password,
        //            redirect = redirect
        //        });

        //        return Content(XmlHelper.ToXml(new JoinBreakoutRoomResponse
        //        {
        //            joinUrl = joinUrl,
        //            Redirect = redirect,
        //            message = "Join URL generated successfully."
        //        }), "application/xml");
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, XmlHelper.XmlErrorResponse<JoinBreakoutRoomResponse>(
        //            "An error occurred while generating join URL.",
        //            ex.Message));
        //    }
        //}
        //#endregion

        //#region End Breakout Room
        //[HttpPost("end")]
        //public async Task<IActionResult> EndBreakoutRoom(string breakoutRoomID, string password)
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(breakoutRoomID))
        //        {
        //            return Content(XmlHelper.XmlErrorResponse<BreakoutRoomErrorResponseDto>(
        //                "Breakout room ID cannot be null or empty.",
        //                "Invalid input."), "application/xml");
        //        }

        //        var result = await client.EndBreakoutRoomAsync(new EndBreakoutRoomRequest
        //        {
        //            breakoutRoomID = breakoutRoomID,
        //            password = password
        //        });

        //        if (result.returncode == Returncode.FAILED)
        //        {
        //            return Content(XmlHelper.XmlErrorResponse<EndBreakoutRoomResponse>(
        //                "Failed to end breakout room.",
        //                result.message), "application/xml");
        //        }

        //        return Content(XmlHelper.ToXml(new EndBreakoutRoomResponse
        //        {
        //            breakoutRoomID = breakoutRoomID,
        //            message = "Breakout room ended successfully."
        //        }), "application/xml");
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, XmlHelper.XmlErrorResponse<EndBreakoutRoomResponse>(
        //            "An error occurred while ending breakout room.",
        //            ex.Message));
        //    }
        //}
        //#endregion

        //#region Get Breakout Room Info
        //[HttpGet("info")]
        //public async Task<IActionResult> GetBreakoutRoomInfo(string breakoutRoomID, string password)
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(breakoutRoomID))
        //        {
        //            return Content(XmlHelper.XmlErrorResponse<BreakoutRoomErrorResponseDto>(
        //                "Breakout room ID cannot be null or empty.",
        //                "Invalid input."), "application/xml");
        //        }

        //        var result = await client.GetBreakoutRoomInfoAsync(new GetBreakoutRoomInfoRequest
        //        {
        //            breakoutRoomID = breakoutRoomID,
        //            password = password
        //        });

        //        if (result.returncode == Returncode.FAILED)
        //        {
        //            return Content(XmlHelper.XmlErrorResponse<GetBreakoutRoomInfoResponse>(
        //                "Failed to retrieve breakout room info.",
        //                result.message), "application/xml");
        //        }

        //        return Content(XmlHelper.ToXml(new GetBreakoutRoomInfoResponse
        //        {
        //            breakoutRoomID = breakoutRoomID,
        //            meetingName = result.meetingName,
        //            participantCount = result.participantCount,
        //            duration = result.duration,
        //            createTime = result.createTime,
        //            message = "Breakout room info retrieved successfully."
        //        }), "application/xml");
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, XmlHelper.XmlErrorResponse<GetBreakoutRoomInfoResponse>(
        //            "An error occurred while retrieving breakout room info.",
        //            ex.Message));
        //    }
        //}
        //#endregion

        //#region Update Breakout Room
        //[HttpPost("update")]
        //public async Task<IActionResult> UpdateBreakoutRoom(string breakoutRoomID, int durationInMinutes, List<string> attendeeIDs, string moderatorPW, string attendeePW)
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(breakoutRoomID))
        //        {
        //            return Content(XmlHelper.XmlErrorResponse<BreakoutRoomErrorResponseDto>(
        //                "Breakout room ID cannot be null or empty.",
        //                "Invalid input."), "application/xml");
        //        }

        //        var result = await client.UpdateBreakoutRoomAsync(new UpdateBreakoutRoomRequest
        //        {
        //            breakoutRoomID = breakoutRoomID,
        //            durationInMinutes = durationInMinutes,
        //            attendeeIDs = attendeeIDs,
        //            moderatorPW = moderatorPW,
        //            attendeePW = attendeePW
        //        });

        //        if (result.returncode == Returncode.FAILED)
        //        {
        //            return Content(XmlHelper.XmlErrorResponse<UpdateBreakoutRoomResponse>(
        //                "Failed to update breakout room.",
        //                result.message), "application/xml");
        //        }

        //        return Content(XmlHelper.ToXml(new UpdateBreakoutRoomResponse
        //        {
        //            breakoutRoomID = breakoutRoomID,
        //            message = "Breakout room updated successfully."
        //        }), "application/xml");
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, XmlHelper.XmlErrorResponse<UpdateBreakoutRoomResponse>(
        //            "An error occurred while updating breakout room.",
        //            ex.Message));
        //    }
        //}
        //#endregion

        //#region Delete Breakout Room
        //[HttpDelete("delete")]
        //public async Task<IActionResult> DeleteBreakoutRoom(string breakoutRoomID, string password)
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(breakoutRoomID))
        //        {
        //            return Content(XmlHelper.XmlErrorResponse<BreakoutRoomErrorResponseDto>(
        //                "Breakout room ID cannot be null or empty.",
        //                "Invalid input."), "application/xml");
        //        }

        //        var result = await client.DeleteBreakoutRoomAsync(new DeleteBreakoutRoomRequest
        //        {
        //            breakoutRoomID = breakoutRoomID,
        //            password = password
        //        });

        //        if (result.returncode == Returncode.FAILED)
        //        {
        //            return Content(XmlHelper.XmlErrorResponse<DeleteBreakoutRoomResponse>(
        //                "Failed to delete breakout room.",
        //                result.message), "application/xml");
        //        }

        //        return Content(XmlHelper.ToXml(new DeleteBreakoutRoomResponse
        //        {
        //            breakoutRoomID = breakoutRoomID,
        //            message = "Breakout room deleted successfully."
        //        }), "application/xml");
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, XmlHelper.XmlErrorResponse<DeleteBreakoutRoomResponse>(
        //            "An error occurred while deleting breakout room.",
        //            ex.Message));
        //    }
        //}
        //#endregion

    }
}
