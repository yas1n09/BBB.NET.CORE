using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.Entities
{
    public class BreakoutRoomInfo
    {
        /// <summary>
        /// Kırılım odasının benzersiz kimliği.
        /// </summary>
        public string RoomID { get; set; }

        /// <summary>
        /// Kırılım odasının adı.
        /// </summary>
        public string RoomName { get; set; }

        /// <summary>
        /// Kırılım odasındaki katılımcı sayısı.
        /// </summary>
        public int ParticipantCount { get; set; }

        /// <summary>
        /// Kırılım odasına atanan moderatörlerin listesi.
        /// </summary>
        public List<string> Moderators { get; set; }

        /// <summary>
        /// Kırılım odasında yer alan katılımcıların listesi.
        /// </summary>
        public List<string> Participants { get; set; }

        /// <summary>
        /// Kırılım odasının aktif durumda olup olmadığını belirler.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Kırılım odasının oluşturulma tarihi.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Kırılım odasının süresi (dakika cinsinden).
        /// </summary>
        public int Duration { get; set; }
    }
}
