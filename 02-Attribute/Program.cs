using System.Reflection;
using System.Text.Json.Serialization;

namespace _02_Attribute
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var p = new People();
                p.Name = "xujinbin";
                p.Description = "xujinbinxujinbinxujinbin";
                Validate(p);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            //[DataMember]要加上[DataCntract]才有效
            //Json序列化后，字段名按照[DataMember(Name="Name")]来
            //{"name":"小狗","order_no":"20240729164929288"}
            var a = new AnimalModel()
            {
                orderNo = DateTime.Now.ToString("yyyyMMddHHmmddfff"),
                plName = "小狗"
            };

            var s = Newtonsoft.Json.JsonConvert.SerializeObject(a);

            Console.ReadKey();
        }

        public static void Validate(object obj)
        {
            var t = obj.GetType();
            var properties = t.GetProperties();
            foreach (var property in properties)
            {
                if (!property.IsDefined(typeof(StringLengthAttribute), false))
                {
                    continue;
                }

                var attributes = property.GetCustomAttributes();

                foreach (var attribute in attributes)
                {
                    var maxNumLength = (int)attribute.GetType().GetProperty("MaxNumLength").GetValue(attribute);

                    //获取属性的值
                    var propertyValue = property.GetValue(obj) as string;
                    if (propertyValue != null)
                    {
                        if (propertyValue.Length > maxNumLength)
                        {
                            throw new Exception($"属性{property.Name}的值{propertyValue}的长度超过了{maxNumLength}");
                        }
                    }

                }
            }
        }
    }
}
