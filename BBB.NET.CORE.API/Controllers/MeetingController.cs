using BBB.NET.CORE.BaseClasses;
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
        public async Task<IActionResult> CreateMeeting(string name, string meetingID, bool record = false, int duration = 60, int maxParticipants = 20, bool muteOnStart = true, bool webcamsOnlyForModerator = false, string moderatorPW = "", string attendeePW = "", string welcome = "Welcome to the meeting!", string logoutURL = "")
        {
            try
            {
                var request = new CreateMeetingRequest
                {
                    name = name,
                    meetingID = meetingID,
                    record = record,
                    duration = duration,
                    maxParticipants = maxParticipants,
                    muteOnStart = muteOnStart,
                    webcamsOnlyForModerator = webcamsOnlyForModerator,
                    moderatorPW = moderatorPW,
                    attendeePW = attendeePW,
                    welcome = welcome,
                    logoutURL = logoutURL
                };

                var result = await client.CreateMeetingAsync(request);

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
                    maxParticipants = result.maxParticipants,
                    voiceBridge = result.voiceBridge,
                    dialNumber = result.dialNumber,
                    createDate = result.createDate,
                    hasUserJoined = result.hasUserJoined,
                    duration = result.duration,
                    hasBeenForciblyEnded = result.hasBeenForciblyEnded,
                    participantCount = result.participantCount,
                    listenerCount = result.listenerCount,
                    voiceParticipantCount = result.voiceParticipantCount,
                    videoCount = result.videoCount,
                    recording = result.recording,
                    hasBeenLocked = result.hasBeenLocked,
                    hasStarted = result.hasStarted,
                    running = result.running,
                    metadata = result.metadata,
                    attendeeList = result.attendeeList
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

        //#region Create Meeting

        //[HttpPost("create")]
        //public async Task<IActionResult> CreateMeeting(string name, string meetingID, bool record = false, int duration = 60, int maxParticipants = 20, bool muteOnStart = false, bool webcamsOnlyForModerator = false)
        //{
        //    try
        //    {
        //        var result = await client.CreateMeetingAsync(new CreateMeetingRequest
        //        {
        //            name = name,
        //            meetingID = meetingID,
        //            record = record,
        //            duration = duration,
        //            maxParticipants = maxParticipants,
        //            muteOnStart = muteOnStart,
        //            webcamsOnlyForModerator = webcamsOnlyForModerator
        //        });


        //        if (result.returncode == Returncode.FAILED)
        //        {
        //            return Content(XmlHelper.ToXml(new MeetingErrorResponseDto
        //            {
        //                Message = "Failed to create meeting.",
        //                Details = result.message
        //            }), "application/xml");
        //        }

        //        return Content(XmlHelper.ToXml(new CreateMeetingResponse
        //        {
        //            meetingID = result.meetingID,
        //            internalMeetingID = result.internalMeetingID,
        //            parentMeetingID = result.parentMeetingID,
        //            moderatorPW = result.moderatorPW,
        //            attendeePW = result.attendeePW,
        //            createTime = result.createTime,
        //            voiceBridge = result.voiceBridge,
        //            dialNumber = result.dialNumber,
        //            createDate = result.createDate,
        //            hasUserJoined = result.hasUserJoined,
        //            duration = result.duration,
        //            maxParticipants = result.maxParticipants,
        //            hasBeenForciblyEnded = result.hasBeenForciblyEnded,

        //            message = "Meeting created successfully."
        //        }), "application/xml");
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, XmlHelper.ToXml(new MeetingErrorResponseDto
        //        {
        //            Message = "An error occurred during meeting creation.",
        //            Details = ex.Message
        //        }));
        //    }
        //}
        //#endregion


        #region End Meeting

        [HttpPost("end")]
        public async Task<IActionResult> EndMeeting(string meetingID, string password)
        {
            try
            {
                var result = await client.EndMeetingAsync(new EndMeetingRequest
                {
                    meetingID = meetingID,
                    password = password
                });

                if (result.returncode == Returncode.FAILED)
                {
                    return Content(XmlHelper.ToXml(new MeetingErrorResponseDto
                    {
                        Message = "Failed to end meeting.",
                        Details = result.message
                    }), "application/xml");
                }

                return Content(XmlHelper.ToXml(new MeetingEndDto
                {
                    MeetingID = meetingID,
                    Message = "Meeting ended successfully."
                }), "application/xml");
            }
            catch (Exception ex)
            {
                return StatusCode(500, XmlHelper.ToXml(new MeetingErrorResponseDto
                {
                    Message = "An error occurred while ending the meeting.",
                    Details = ex.Message
                }));
            }
        }

        #endregion


        #region Join Meeting

        [HttpGet("join")]
        public async Task<IActionResult> JoinMeeting(string meetingID, string fullName, string password, bool redirect = true, string userdata = "")
        {
            try
            {
                var joinRequest = new JoinMeetingRequest
                {
                    fullName = fullName,
                    meetingID = meetingID,                 
                    password = password,
                    redirect = redirect,  // ToString() gerekmez, doğrudan atanabilir
                    userdata = userdata
                };



                var joinUrl =await client.GetJoinMeetingUrl(joinRequest);

                return Content(XmlHelper.ToXml(new JoinMeetingResponse
                {
                    JoinUrl = joinUrl,
                    Redirect = redirect,
                    Message = "Join URL generated successfully."
                }), "application/xml");
            }
            catch (Exception ex)
            {
                return StatusCode(500, XmlHelper.ToXml(new MeetingErrorResponseDto
                {
                    Message = "An error occurred while generating join URL.",
                    Details = ex.Message
                }));
            }
        }


        #endregion


        #region Is Meeting Running

        [HttpGet("isRunning")]
        public async Task<IActionResult> IsMeetingRunning(string meetingID)
        {
            if (string.IsNullOrEmpty(meetingID))
            {
                return Content(XmlHelper.ToXml(new MeetingErrorResponseDto
                {
                    Message = "Meeting ID cannot be null or empty.",
                    Details = "Invalid input."
                }), "application/xml");
            }

            try
            {
                var response = await client.IsMeetingRunningAsync(new IsMeetingRunningRequest
                {
                    meetingID = meetingID
                });

                return Content(XmlHelper.ToXml(new MeetingStatusDto
                {
                    MeetingID = meetingID,
                    IsRunning = response.running ?? false,
                    Message = response.running == true ? "Meeting is running." : "Meeting is not running."
                }), "application/xml");
            }
            catch (Exception ex)
            {
                return StatusCode(500, XmlHelper.ToXml(new MeetingErrorResponseDto
                {
                    Message = "An error occurred while checking meeting status.",
                    Details = ex.Message
                }));
            }
        }


        #endregion



    }
}
