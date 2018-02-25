using ECDC.MIS.API.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace ECDC.MIS.API.Misc
{
    public static class Helper
    {
        public static AnnualWorkPlan GetCurrentYear(MISContext context)
        {
            return context.AnnualWorkPlan.Where(p => p.AWPName == DateTime.Now.Year.ToString()).FirstOrDefault();
        }

        public static long GetMultiAnnualPlan(MISContext context, AnnualWorkPlan currentYear)
        {
            return context.MultiAnnualWorkPlan.Where(
                p => p.MawpstartYear.Value.Year <= int.Parse(currentYear.AWPName) &&
                p.MawpendYear.Value.Year >= int.Parse(currentYear.AWPName)).Select(p => p.Mawpid).FirstOrDefault();
        }

        public static AnnualWorkPlan GetAwp(MISContext context, long awpId)
        {
            AnnualWorkPlan workingYear;
            if (awpId == 0)
                workingYear = GetCurrentYear(context);
            else
                workingYear = context.AnnualWorkPlan.Where(p => p.Awpid == awpId).Select(p => p).FirstOrDefault();
            return workingYear;
        }

        /// <summary>
        /// Get Activity code for an activity
        /// </summary>
        /// <param name="activity">The activity</param>
        /// <returns>The activity code</returns>
        public static string GetCode(Activity activity)
        {
            try
            {
                string code = "";
                if (activity == null)
                {
                    return code;
                }

                if (activity.Strategy != null)
                {
                    code += string.Format("{0}", activity.Strategy.StartegyName.Remove(0, 8));
                }

                if (activity.Unit != null)
                {
                    code += string.Format("-{0}", activity.Unit.UnitCode);
                }

                if (activity.Dsp != null)
                {
                    if (activity.Dsp.DspIsCore.GetValueOrDefault())
                    {
                        code += string.Format("-{0}", "CORE");
                    }
                    else
                    {
                        code += string.Format("-{0}", activity.Dsp.DspCode);
                    }
                }

                if (activity.ActivityCodeSequence != null)
                {
                    code += string.Format("-{0}", activity.ActivityCodeSequence);
                }

                if (activity.Awp != null)
                {
                    code += string.Format("-{0}", activity.Awp.AWPName);
                }

                return code.Trim();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

            
        }

        public static void SetExpenseLayout(Expense expense)
        {
            if (expense.ExpenseType == null)
            {
                expense.AmountVisibility = true;
                expense.StartDateVisibility = false;
                expense.EndDateVisibility = false;
                expense.ProcFieldsVisibility = false;
                expense.MeetingFieldsVisibility = false;
                expense.MeetingMissionFieldsVisibility = false;
                expense.GrantFieldsVisibility = false;
                expense.BudgetOfficerFieldsVisibility = false;
                expense.BudgetlineVisibility = false;
                return;
            }

            if (expense.ExpenseType.ExpenseTypeIsProcurement.GetValueOrDefault())
            {
                expense.AmountVisibility = true;
                expense.StartDateVisibility = true;
                expense.EndDateVisibility = true;
                expense.ProcFieldsVisibility = true;
                expense.MeetingFieldsVisibility = false;
                expense.MeetingMissionFieldsVisibility = false;
                expense.GrantFieldsVisibility = false;
                expense.BudgetlineVisibility = true;
                expense.BudgetOfficerFieldsVisibility = true;
            }

            if (expense.ExpenseType.ExpenseTypeIsMeeting.GetValueOrDefault())
            {

                expense.AmountVisibility = true;
                expense.StartDateVisibility = true;
                expense.EndDateVisibility = true;
                expense.ProcFieldsVisibility = false;
                expense.MeetingFieldsVisibility = true;
                expense.MeetingMissionFieldsVisibility = true;
                expense.GrantFieldsVisibility = false;
                expense.BudgetlineVisibility = true;
                expense.BudgetOfficerFieldsVisibility = true;
                //expense.LabelStartDate = "Start date";
            }

            if (expense.ExpenseType.ExpenseTypeIsMission.GetValueOrDefault())
            {
                expense.AmountVisibility = true;
                expense.StartDateVisibility = true;
                expense.EndDateVisibility = true;
                expense.ProcFieldsVisibility = false;
                expense.MeetingFieldsVisibility = false;
                expense.MeetingMissionFieldsVisibility = true;
                expense.GrantFieldsVisibility = false;
                expense.BudgetlineVisibility = true;
                expense.BudgetOfficerFieldsVisibility = false;
                //expense.LabelStartDate = "Start date";
            }

            if (expense.ExpenseType.ExpenseTypeIsGrant.GetValueOrDefault())
            {
                expense.AmountVisibility = true;
                expense.StartDateVisibility = true;
                expense.EndDateVisibility = true;
                expense.ProcFieldsVisibility = false;
                expense.MeetingFieldsVisibility = false;
                expense.MeetingMissionFieldsVisibility = false;
                expense.GrantFieldsVisibility = true;
                expense.BudgetlineVisibility = true;
                expense.BudgetOfficerFieldsVisibility = true;
                //expense.LabelStartDate = "Publication date";
            }

            

            //For expense type Other
            if (expense.ExpenseType.ExpenseTypeIsGeneral.GetValueOrDefault())
            {
                expense.AmountVisibility = true;
                expense.StartDateVisibility = false;
                expense.EndDateVisibility = false;
                expense.ProcFieldsVisibility = false;
                expense.MeetingFieldsVisibility = false;
                expense.MeetingMissionFieldsVisibility = false;
                expense.GrantFieldsVisibility = false;
                expense.BudgetlineVisibility = true;
                expense.BudgetOfficerFieldsVisibility = false;
            }

            if (expense.ExpenseType.ExpenseTypeName == "Internal work")
            {
                expense.AmountVisibility = false;
                expense.StartDateVisibility = false;
                expense.EndDateVisibility = false;
                expense.ProcFieldsVisibility = false;
                expense.MeetingFieldsVisibility = false;
                expense.MeetingMissionFieldsVisibility = false;
                expense.GrantFieldsVisibility = false;
                expense.BudgetlineVisibility = false;
                expense.BudgetOfficerFieldsVisibility = false;
            }
        }

        /// <summary>
        /// Get list of activityCode
        /// </summary>
        /// <param name="currentYear"></param>
        /// <returns></returns>
        public static List<SelectListItem> GetActivityCodeList(MISContext context, AnnualWorkPlan currentYear)
        {
            return GetActivityCodeList(context, currentYear.Awpid);
        }

        public static List<SelectListItem> GetActivityCodeList(MISContext context, long awpId)
        {
            //Get list of activityCode and put in Viewbag
            List<SelectListItem> activityCodeList = context.Activity
               .Include(p => p.Strategy)
               .Include(p => p.Unit)
               .Include(p => p.Dsp)
               .Include(p => p.Awp)
               //.Where(p => p.AWPId == awpId).Where(p => GetActivityCode(p)).ToList()
               .Where(p => p.AWPId == awpId)
               .Where(p=>p.ActivityIsDeleted != true).ToList()
               .Select(p => new SelectListItem() {
                   Value = p.ActivityId.ToString(),
                   Text = GetActivityCode(p),
                   
                   //ExtraData = item.AWPId.ToString(),
               }).OrderBy(p => p.Text).ToList();
            activityCodeList.Insert(0, new SelectListItem() { Text = "--", Value = "0" });
            return activityCodeList;
        }

        /// <summary>
        /// Get user authorization on one specific MIS role
        /// </summary>
        /// <param name="context">The database context</param>
        /// <param name="currentUser">The userApplication</param>
        /// <param name="userAccess">The UserAccess role we want to query</param>
        /// <returns>Bool</returns>
        public static bool GetUserAuthorization(MISContext context, UserApplication currentUser, UserAccess userAccess)
        {
            if (currentUser.UserExternalTool != null)
            {
                foreach (var item in currentUser.UserExternalTool.Where(p => p.UserExternalToolIsDeleted != true))
                {
                    if (context.ExternalToolsRole.Where(p => p.ExternalToolRoleId == item.ExternalToolRoleId).Select(p => p.ExternalToolRoleName).FirstOrDefault() == userAccess.ToString())
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
     
    }

        #region GetPicture

        public static byte[] ImageToByte(string imgPath)
        {
            Image img = Image.FromFile(imgPath);
            using (MemoryStream mStream = new MemoryStream())
            {
                img.Save(mStream, img.RawFormat);
                return mStream.ToArray();
            }
        }

        #endregion

        #region private methods

        private static string GetActivityCode(Activity p)
        {
            return Helper.GetCode(p);
            //return true;
        }

        #endregion

        #region budgetTransfer

        public static long GetBtYear(PendingExpenseTransfer p)
        {
            if (p.ExpenseIdSourceNavigation == null && p.ExpenseIdTargetNavigation == null) return 0; //Artung : in 2016 there are transfer type and 2
            return p.ExpenseIdSourceNavigation != null ? p.ExpenseIdSourceNavigation.Activity.AWPId.GetValueOrDefault() : p.ExpenseIdTargetNavigation.Activity.AWPId.GetValueOrDefault();
        }

        #endregion

        //public static void EventLog(string eventType, string eventDescription, EventLogEntryType eventLogEntryType)
        //{
        //    //System.Diagnostics.en
        //    //System.Diagnostics.EventLog.WriteEntry(eventType, string.Format("{0} - {1}", DateTime.Now.ToLongTimeString(), eventDescription), eventLogEntryType);
        //}
    }
}
