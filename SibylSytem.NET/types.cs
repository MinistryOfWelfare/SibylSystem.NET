namespace SibylSytem.NET
{
    public partial class CheckTokenResult
    {
        public bool? Success { get; set; }
        public bool? Result { get; set; }
        public object Error { get; set; }
    }

    public partial class BanResult
    {
        public bool? Success { get; set; }
        public Result Result { get; set; }
        public object Error { get; set; }
    }

    public partial class Result
    {
        public Ban PreviousBan { get; set; }
        public Ban CurrentBan { get; set; }
    }

    public partial class Ban
    {
        public long? UserId { get; set; }
        public bool? Banned { get; set; }
        public string Reason { get; set; }
        public string Message { get; set; }
        public string BanSourceUrl { get; set; }
        public long? BannedBy { get; set; }
        public long? CrimeCoefficient { get; set; }
        public string Date { get; set; }
        public string[] BanFlags { get; set; }
    }

    public partial class GetInfoResult
    {
        public bool? Success { get; set; }
        public Result Ban { get; set; }
        public object Error { get; set; }
    }

    public partial class UnbanResult
    {
        public bool? Success { get; set; }
        public string Result { get; set; }
        public object Error { get; set; }
    }
}
