using BBB.NET.CORE.BigBlueButtonAPIClients;
using BBB.NET.CORE.DTOs;
using BBB.NET.CORE.Enums;
using BBB.NET.CORE.Helpers;
using BBB.NET.CORE.Requests.Meeting;
using BBB.NET.CORE.Responses.Meeting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BBB.NET.CORE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingController : ControllerBase
    {
        private readonly BigBlueButtonAPIClient client;

        public MeetingController(BigBlueButtonAPIClient client)
        {
            this.client = client;
        }

        #region Create Meeting

        [HttpPost("create")]
        public async Task<IActionResult> CreateMeeting(string name, string meetingID, bool record = false,int duration = 60, int maxParticipants = 20, bool muteOnStart = false, bool webcamsOnlyForModerator = false )
        {
            try
            {
                var result = await client.CreateMeetingAsync(new CreateMeetingRequest 
                {
                    name = name,
                    meetingID = meetingID,
                    record = record,
                    duration = duration,
                    maxParticipants = maxParticipants,
                    muteOnStart = muteOnStart,
                    webcamsOnlyForModerator = webcamsOnlyForModerator
                });


                if (result.returncode == Returncode.FAILED)
                {
                    return Content(XmlHelper.ToXml(new MeetingErrorResponseDto
                    {
                        Message = "Failed to create meeting.",
                        Details = result.message
                    }), "application/xml");
                }

                return Content(XmlHelper.ToXml(new CreateMeetingResponse
                {
                    meetingID = result.meetingID,
                    internalMeetingID = result.internalMeetingID,
                    parentMeetingID = result.parentMeetingID,
                    moderatorPW = result.moderatorPW,
                    attendeePW = result.attendeePW,
                    createTime = result.createTime,
                    voiceBridge = result.voiceBridge,
                    dialNumber = result.dialNumber,
                    createDate = result.createDate,
                    hasUserJoined = result.hasUserJoined,
                    duration = result.duration,
                    maxParticipants = result.maxParticipants,
                    hasBeenForciblyEnded = result.hasBeenForciblyEnded,
                    
                    message = "Meeting created successfully."
                }), "application/xml");
            }
            catch (Exception ex)
            {
                return StatusCode(500, XmlHelper.ToXml(new MeetingErrorResponseDto
                {
                    Message = "An error occurred during meeting creation.",
                    Details = ex.Message
                }));
            }
        }
        #endregion




    }
}
