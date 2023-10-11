using System.ComponentModel;

namespace SmartGenealogy.Domain.Enums;

public enum UploadType : byte
{
    [Description(@"Products")]
    Product,
    [Description(@"ProfilePictures")]
    ProfilePicture,
    [Description(@"Documents")]
    Document
}