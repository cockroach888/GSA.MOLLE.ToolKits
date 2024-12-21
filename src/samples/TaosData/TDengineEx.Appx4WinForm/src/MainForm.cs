using GSA.ToolKits.DBUtility.TDengine;

namespace TDengineEx.Appx4WinForm;

public partial class MainForm : Form
{
    private ITDengineConnector? _connector;


    public MainForm()
    {
        InitializeComponent();
    }


    private void MainForm_Load(object sender, EventArgs e)
    {
        TDengineOptions options = new()
        {
            Host = "127.0.0.1",
            Port = 10101,
            UserName = "root",
            Password = "taosdata",
            TimeZone = "Asia/Shanghai",
            VersionSelector = TDengineVersion.V3,
            KeyNameRegex = [
                "last_row\\((.+?)\\)",
                "last\\((.+?)\\)",
                "first\\((.+?)\\)",
                "sum\\((.+?)\\)"
            ]
        };

        _connector = TDengineConnectorProvider.Default.Create(options);
    }

    private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
    {
        if (_connector is not null)
        {
            using (_connector) { }
        }
    }


    private async void BtnConnection_Click(object sender, EventArgs e)
    {
        TDengineOptions options = new()
        {
            Host = "127.0.0.1",
            Port = 10101,
            UserName = "root",
            Password = "taosdata",
            TimeZone = "Asia/Shanghai",
            VersionSelector = TDengineVersion.V3,
            KeyNameRegex = [
                "last_row\\((.+?)\\)",
                "last\\((.+?)\\)",
                "first\\((.+?)\\)",
                "sum\\((.+?)\\)"
            ]
        };

        using ITDengineConnector connector = TDengineConnectorProvider.Default.Create(options);

        TDengineQueryParam param = new("show databases;");
        string? result = await connector.ExecuteAsync(param).ConfigureAwait(false);

        if (string.IsNullOrWhiteSpace(result) is false)
        {
            BeginInvoke(() =>
            {
                txtMessage.Text = result;
            });
        }
    }

    private async void BtnQueryLog_Click(object sender, EventArgs e)
    {
        if (_connector is null)
        {
            txtMessage.Text = "还未创建 TDengine RESTful API 连接器，请确认后重试。";
            return;
        }

        TDengineQueryParam param = new("select * from log.keeper_monitor;");
        string? result = await _connector.ExecuteAsync(param).ConfigureAwait(false);

        if (string.IsNullOrWhiteSpace(result) is false)
        {
            BeginInvoke(() =>
            {
                txtMessage.Text = result;
            });
        }
    }
}