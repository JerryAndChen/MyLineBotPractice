using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// ImageMessage 的摘要描述
/// </summary>
public class ImageMessage:ILineMessage
{
    private string _type = "image";
    private string _originalContentUrl;
    private string _previewImageUrl;
    public ImageMessage()
    {
        //
        // TODO: 在這裡新增建構函式邏輯
        //
    }
    public ImageMessage(string originalContentUrl, string previewImageUrl)
    {
        _originalContentUrl = originalContentUrl;
        _previewImageUrl = previewImageUrl;
    }

    public string type
    {
        get
        {
            return _type;
        }

        set
        {
            _type = "image";
        }
    }

    public string OriginalContentUrl
    {
        get
        {
            return _originalContentUrl;
        }

        set
        {
            _originalContentUrl = value;
        }
    }

    public string PreviewImageUrl
    {
        get
        {
            return _previewImageUrl;
        }

        set
        {
            _previewImageUrl = value;
        }
    }
}