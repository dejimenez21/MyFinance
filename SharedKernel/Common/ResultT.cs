﻿namespace SharedKernel.Common;

public class Result<TValue> : Result
{
    private readonly TValue? _value;

    protected internal Result(TValue? value)
        : base()
    {
        _value = value;
    }

    protected internal Result(Error error)
        : base(error)
    {
    }

    public TValue Value => IsSuccess
        ? _value!
        : throw new InvalidOperationException("The value of a failure result can not be accessed.");

    public static implicit operator Result<TValue>(TValue? value) => Create(value);
    public static implicit operator Result<TValue>(Error error) => new Result<TValue>(error); 
}