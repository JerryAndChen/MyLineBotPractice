using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// BubbleMessage 的摘要描述
/// </summary>
public class BubbleMessage :ILineMessage
{
    private string _type = "bubble";
    private string _headTitle;
    private string _image;
    private string _title;
    private string _description;
    private List<Button> _buttons;
    public BubbleMessage()
    {
        //
        // TODO: 在這裡新增建構函式邏輯
        //
    }
    public BubbleMessage(string headTitle, string image, string title, string description, List<Button> buttons)
    {
        _headTitle = headTitle;
        _image = image;
        _title = title;
        _description = description;
        _buttons = buttons;
    }

    public string HeadTitle
    {
        get
        {
            return _headTitle;
        }

        set
        {
            _headTitle = value;
        }
    }

    public string Image
    {
        get
        {
            return _image;
        }

        set
        {
            _image = value;
        }
    }

    public string Title
    {
        get
        {
            return _title;
        }

        set
        {
            _title = value;
        }
    }

    public string Description
    {
        get
        {
            return _description;
        }

        set
        {
            _description = value;
        }
    }

    public List<Button> Buttons
    {
        get
        {
            return _buttons;
        }

        set
        {
            _buttons = value;
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
            _type = "bubble";
        }
    }

}