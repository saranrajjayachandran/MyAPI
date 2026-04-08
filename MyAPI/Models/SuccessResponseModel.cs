using System;

namespace MyAPI.Models;

public class SuccessResponseModel<T>
{
    public string resultCode {get; set;}
    public string errorMsg {get; set;}
    public List<T> Data {get; set;}
}
