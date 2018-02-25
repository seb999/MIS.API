using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class Procurement
    {
        public Procurement()
        {
            Expense = new HashSet<Expense>();
            ProcurementCompagnyDispatch = new HashSet<ProcurementCompagnyDispatch>();
            ProcurementCompagnyReceived = new HashSet<ProcurementCompagnyReceived>();
            ProcurementContract = new HashSet<ProcurementContract>();
            ProcurementCorrigendum = new HashSet<ProcurementCorrigendum>();
            ProcurementEvaluationCommittee = new HashSet<ProcurementEvaluationCommittee>();
            ProcurementMember = new HashSet<ProcurementMember>();
            ProcurementPackage = new HashSet<ProcurementPackage>();
            ProcurementTender = new HashSet<ProcurementTender>();
        }

        public long ProcId { get; set; }
        public decimal? ProcContractedAmount { get; set; }
        public bool? ProcImplementationIsProc { get; set; }
        public bool? ProcImplementationIsGrant { get; set; }
        public bool? ProcTypeIsOpen { get; set; }
        public bool? ProcTypeIsNegociated { get; set; }
        public string ProcDetailContractNumber { get; set; }
        public string ProcDetailNumberLot { get; set; }
        public bool? ProcDetailCpcgIsYes { get; set; }
        public bool? ProcDetailCpcgIsNo { get; set; }
        public DateTime? ProcDetailSubmissionDocCpcg { get; set; }
        public DateTime? ProcDetailConsultationCpcg { get; set; }
        public string ProcDetailDurationYear { get; set; }
        public string ProcDetailDurationMonth { get; set; }
        public string ProcDetailDurationWeek { get; set; }
        public string ProcDetailDurationComment { get; set; }
        public DateTime? ProcDetailExpectedContractSignature { get; set; }
        public DateTime? ProcDetailExpectedLaunch { get; set; }
        public DateTime? ProcDetailExpectedContractStartDate { get; set; }
        public DateTime? ProcLaunchCpcgmeeting { get; set; }
        public bool? ProcLaunchCpcgmeetingIsApplicable { get; set; }
        public string ProcLaunchReference { get; set; }
        public DateTime? ProcLaunchArrivalProc { get; set; }
        public DateTime? ProcLaunchDispatchContractNoticeOj { get; set; }
        public DateTime? ProcLaunchEstimatedPublicationOj { get; set; }
        public DateTime? ProcLauchPublicationOj { get; set; }
        public DateTime? ProcLaunchPublicationEcdcWebsite { get; set; }
        public DateTime? ProcLaunchArrivalCorrigenda { get; set; }
        public DateTime? ProcLaunchPublicationCorrigendaOj { get; set; }
        public DateTime? ProcLaunchPublicationCorrigendaWebsite { get; set; }
        public DateTime? ProcLaunchDeadlineClarification { get; set; }
        public string ProcLaunchNumberQa { get; set; }
        public string ProcLaunchNameQa { get; set; }
        public string ProcLaunchConfirmationSubmission { get; set; }
        public DateTime? ProcLaunchDeadline { get; set; }
        public bool? ProcLaunchIsFavorable { get; set; }
        public bool? ProcLaunchIsNotFavorable { get; set; }
        public bool? ProcLaunchIsNotApplicable { get; set; }
        public DateTime? ProcOpeningCommetteAppointedDate { get; set; }
        public DateTime? ProcOpeningDate { get; set; }
        public DateTime? ProcEvalCommetteeAppointed { get; set; }
        public DateTime? ProcEvalEvalCommetteeMeeting { get; set; }
        public DateTime? ProcEvalReportSignature { get; set; }
        public DateTime? ProcAwardConsultationCed { get; set; }
        public DateTime? ProcAwardDecision { get; set; }
        public DateTime? ProcAwardNotificationLetter { get; set; }
        public DateTime? ProcAward14DayStandstill { get; set; }
        public bool? ProcAward14DayStandstillIsYes { get; set; }
        public bool? ProcAward14DayStandstillIsNo { get; set; }
        public decimal? ProcAwardAmount { get; set; }
        public string ProcAwardEvidenceExclusionCriteria { get; set; }
        public DateTime? ProcPublicationDeadline { get; set; }
        public DateTime? ProcPublicationDispatchOj { get; set; }
        public DateTime? ProcPublicationPublicationOj { get; set; }
        public DateTime? ProcPublicationOnWeb { get; set; }
        public string ProcNegociatedProcedureReference { get; set; }
        public DateTime? ProcNegociatedProcedureDispatch { get; set; }
        public DateTime? ProcNegociatedProcedureDeadline { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public ICollection<Expense> Expense { get; set; }
        public ICollection<ProcurementCompagnyDispatch> ProcurementCompagnyDispatch { get; set; }
        public ICollection<ProcurementCompagnyReceived> ProcurementCompagnyReceived { get; set; }
        public ICollection<ProcurementContract> ProcurementContract { get; set; }
        public ICollection<ProcurementCorrigendum> ProcurementCorrigendum { get; set; }
        public ICollection<ProcurementEvaluationCommittee> ProcurementEvaluationCommittee { get; set; }
        public ICollection<ProcurementMember> ProcurementMember { get; set; }
        public ICollection<ProcurementPackage> ProcurementPackage { get; set; }
        public ICollection<ProcurementTender> ProcurementTender { get; set; }
    }
}
