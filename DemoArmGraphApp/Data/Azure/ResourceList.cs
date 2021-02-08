using System.Collections.Generic;

namespace DemoArmGraphApp.Data.Azure
{
    public class ResourceList<T>
    {
        public List<T> value { get; set; }
        public string nextLink { get; set; }
    }
}
