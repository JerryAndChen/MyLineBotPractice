using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// StickerMessage 的摘要描述
/// </summary>
public class StickerMessage : ILineMessage
{
    private string _type = "sticker";
    private string _packageId;
    private string _stickerId;
    public StickerMessage()
    {
        //
        // TODO: 在這裡新增建構函式邏輯
        //
    }
    public StickerMessage(string packageId, string stickerId)
    {
        _packageId = packageId;
        _stickerId = stickerId;
    }

    public string PackageId
    {
        get
        {
            return _packageId;
        }

        set
        {
            _packageId = value;
        }
    }

    public string StickerId
    {
        get
        {
            return _stickerId;
        }

        set
        {
            _stickerId = value;
        }
    }

    public string type
    {
        get
        {
            return _type;
        }

        set
        {
            _type = "sticker";
        }
    }
}