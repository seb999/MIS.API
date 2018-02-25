
namespace ECDC.MIS.API.Misc
{
    public enum OperationMode
    {
        View,
        PartialEdit,
        Edit

    }
    public enum Method
    {
        NA,
        SaveActivity,
        SaveExpense,
        UpdatePlatoStatus,
        UpdateExecuteBudgetTransfer,
        SaveProcurement,
        SaveChildProcurement,
        SaveProcurementStages,
        UpdateUserProfile
    }
    public enum MISPage
    {
        HomePage,
        ActivityPage,
        ActivityDetailPage,
        ExpensePage,
        ProcurementPage,
        BudgetTransferPage,
        SearchPage,
        AwpPage,
        DashboardLogsPage,
        MeetingPage,
        MeetingDetailPage,
        ReportPage,
        RequestActivityPage,
        RequestExpensePage,
        RequestFtePage,
        PlatoPage,
        ProjectPage,
        AdminPage
    }
    public enum LogType
    {
        Information,
        Warning,
        Error
    }

    public enum UserAccess
    {
        Procurement,
        ProcurementEdit,
        BudgetTransferAdd,
        Contract,
        Meeting,
        MeetingEdit,
        Admin,
        Dashboard,
        DisplayFTEActual,
    }

    public enum SettingType
    {
        EnableNotification,
        PlatoAWP,
        EnablePlatoEdit,
        MeetingCCEmail,
        MeetingPMMEmail
    }

    public enum HistoryElement
    {
        Amount,
        BudgetLine,
        Name
    }

    public enum ChartName
    {
        MeetingProgrammed,
        MeetingStatus,
        MeetingStatusByUnit,
        ProcurementProgrammed,
        ProcurementStatus,
        BudgetTransferAccumulation,
        BudgetTransferByUnit,
        MeetingBudgetConsumption,
        MeetingBudgetConsumptionByUnit,
    }

    public enum DataFilterElement
    {
        Awp,
        Unit,
        DP,
        Section,
        Activity,
        UserApplication
    }

    public enum MeetingSatus
    {
        Cancelled,
        Executed,
        Planned,
        Initiated,
        Committed,
        CarryForward,
        Outsourced
    }

    public enum MeetingTypeOfApproval
    {
        TypeOfApproval,
        BasicChange,
        CriticalChange,
        NotCriticalChange,
    }

    public enum ProcTimingSatus
    {
        Delay,
        OnTrack,
        AtRisk,
        Signed,
        Cancelled,
    }

    public enum BTStatus
    {
        Approved,
        Rejected,
        Pending,
    }
    public enum BTFlow
    {
        HoUSource,
        HoUTarget,
        Finance,
        Director
    }

    public enum RequestedItemStatus
    {
        Rejected,
        Approved,
        Reset,
        Validation,
    }

    public enum UserRoleType
    {
        HeadOfUnit,
        HeadOfSection,
        PNM,
        Director,
        ProcOfficer,
        HeadOfDP
    }

    public enum BudgetTransferValidationType
    {
        None,
        HoUSourceApproval,
        HoUSourceRejected,
        HoUTargetApproval,
        HoUTargetRejected,
        FinanceInitiatorApproval,
        FinanceInitiatorRejected,
        FinanceApproval,
        FinanceRejected,
    }

    //public enum LogEntryType
    //{
    //    Error,
    //    Application,
    //    Warning,
    //    Miscellaneous,
    //    Notification
    //}


}
