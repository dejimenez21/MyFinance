﻿namespace SharedKernel.Common
{
    public class Error
    {
        public Error(int statusCode, string errorCode, string message)
        {
            StatusCode = statusCode;
            ErrorCode = errorCode;
            Message = message;
            Reasons = new List<Error>();
        }

        public Error(int statusCode, string errorCode, string message, Error reason) : this(statusCode, errorCode, message)
        {
            Reasons.Add(reason);
        }

        public Error(int statusCode, string errorCode, string message, List<Error> reason) : this(statusCode, errorCode, message)
        {
            Reasons = reason;
        }

        public int StatusCode { get; set; }
        public string ErrorCode { get; set; }
        public string Message { get; set; }
        public List<Error> Reasons { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (this.GetType() != obj.GetType()) return false;

            var other = obj as Error;
            return this.ErrorCode == other!.ErrorCode;
        }

        public override int GetHashCode()
        {
            return ErrorCode.GetHashCode();
        }

        public static bool operator ==(Error a, Error b)
        {
            return a is not null && b is not null && a.Equals(b);
        }

        public static bool operator !=(Error a, Error b)
        {
            return !(a == b);
        }
    }
}
