namespace BootstrapBlazorApp.POCO;

public class BusinessResult
{
    public BusinessCode Code { get; set; }

    public string Message { get; set; }
}

public class BusinessResult<T> : BusinessResult
{
    public T Data { get; set; }

}

public enum BusinessCode
{
    Failed = 0,

    Success = 1,

    AppointmentDateExpired = 2,

    AppointmentFull = 3,
}
