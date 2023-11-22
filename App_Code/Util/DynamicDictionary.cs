using System.Collections.Generic;
using System.Dynamic;

/// <summary>
/// DynamicDictionary 的摘要描述
/// </summary>
public class DynamicDictionary:DynamicObject
{
    Dictionary<string, object> dictionary = new Dictionary<string,object>();
    public DynamicDictionary()
    {
        //
        // TODO: 在這裡新增建構函式邏輯
        //
    }
    public int Count()
    {
        return dictionary.Count;
    }
    public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result)
    {
        //if(indexes[0].GetType() == typeof(int))
        //{
        //    //索引 => 數字
        //    int index = (int)indexes[0];
        //    return dictionary.TryGetValue(index, out result);
        //}
        //索引 => 名稱
        string indexName = (string)indexes[0];
        return dictionary.TryGetValue(indexName, out result);
    }
    public override bool TryGetMember(GetMemberBinder binder, out object result)
    {
        return dictionary.TryGetValue(binder.Name, out result);
    }
    public override bool TrySetMember(SetMemberBinder binder, object value)
    {
        dictionary[binder.Name] = value;
        return true;
    }
}