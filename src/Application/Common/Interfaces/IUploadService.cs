﻿namespace SmartGenealogy.Application.Common.Interfaces;

public interface IUploadService
{
    Task<string> UploadAsync(UploadRequest request);
}