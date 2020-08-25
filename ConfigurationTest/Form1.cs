using ConfigurationTest.Utils;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Specialized;
using System.Windows.Forms;

namespace ConfigurationTest
{
    public partial class FormTest : Form
    {
        public FormTest()
        {
            InitializeComponent();
        }

        private void FormTest_Load(object sender, EventArgs e)
        {
            // 加载App.config配置文件中的appSettings中的配置信息
            NameValueCollection appSetting = System.Configuration.ConfigurationManager.AppSettings;
            // 将appSetting中的信息存储到netCore的配置信息中
            var res = ConvertHelper.ConvertCollectionToKeyValuePair(appSetting);
            var builder = new ConfigurationBuilder();
            // config就是想要的格式
            IConfiguration config = builder.AddInMemoryCollection(res).Build();
            Console.WriteLine(config["COMMAND_TIMEOUT"]);
            // todo:上面的基本已经满足需要了，已经将App.config中的配置信息存储到了config文件中
            // 但是这些配置信息被放到了config的顶层，我想将这些配置信息放到appSetting中，然后将appSetting放到config的顶层。

            // 配置文件中的json格式现在已经可以达到这种格式
            // {"COMMAND_TIMEOUT":1800}
            // 想做成这种格式
            // {"appSetting":{"COMMAND_TIMEOUT":1800}}
        }
    }
}