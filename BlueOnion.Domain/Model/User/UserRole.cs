
using System;

namespace BlueOnion.Domain.Model
{
    /// <summary>
    /// Exposed User Role Association
    /// see http://lostechies.com/jimmybogard/2014/03/12/avoid-many-to-many-mappings-in-orms/
    /// </summary>
    public class UserRole
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }

        public User User { get; set; }
        public Role Role { get; set; }
    }
}
