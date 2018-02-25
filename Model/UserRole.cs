using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECDC.MIS.API.Model
{
    public partial class UserRole:ILookupData
    {
        public UserRole()
        {
            UserApplicationUserRole = new HashSet<UserApplication>();
            UserApplicationUserRoleIdBisNavigation = new HashSet<UserApplication>();
        }

        public long UserRoleId { get; set; }
        public string UserRoleName { get; set; }
        public string UserRoleDescription { get; set; }
        public int? UserRoleApprovalLevel { get; set; }
        public int? UserRoleEditLevel { get; set; }
        public bool? UserRoleIsHeadOfSection { get; set; }
        public bool? UserRoleIsHeadOfUnit { get; set; }
        public bool? UserRoleIsHeadOfUnitDeputy { get; set; }
        public bool? UserRoleIsDspCoordinator { get; set; }
        public bool? UserRoleIsDspCoordinatorDeputy { get; set; }
        public bool? UserRoleIsFinance { get; set; }
        public bool? UserRoleIsExecutive { get; set; }
        public bool? UserRoleIsPlanningMonitoring { get; set; }
        public bool? UserRoleIsDirector { get; set; }
        public bool? UserRoleIsResourceOfficer { get; set; }
        public bool? UserRoleIsNone { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }
        public bool? UserRoleIsFinanceAssistant { get; set; }
        public bool? UserRoleIsProcurementOfficer { get; set; }

        public ICollection<UserApplication> UserApplicationUserRole { get; set; }
        public ICollection<UserApplication> UserApplicationUserRoleIdBisNavigation { get; set; }

        #region Lookup

        [NotMapped]
        public long Value
        {
            get { return UserRoleId; }
            set { Value = value; }
        }

        [NotMapped]
        public string Text
        {
            get { return UserRoleName; }
            set { Text = value; }
        }

        [NotMapped]
        public bool IsInactive { get; set; }

        #endregion
    }
}
