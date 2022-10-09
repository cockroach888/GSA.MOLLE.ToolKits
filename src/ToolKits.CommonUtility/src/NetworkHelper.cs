//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：NetworkHelper.cs
// 项目名称：魂哥常用工具集
// 创建时间：2022-10-09 12:22:19
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Net;

namespace GSA.ToolKits.CommonUtility;

/// <summary>
/// 网络与通信助手类
/// </summary>
public static class NetworkHelper
{
    /// <summary>
    /// 获取真实有效的本地IP地址
    /// </summary>
    /// <returns>本地IP地址</returns>
    public static string GetIpAddress()
    {
        try
        {
            UnicastIPAddressInformation? mostSuitableIp = null;
            NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface network in networkInterfaces)
            {
                if (network.OperationalStatus is not OperationalStatus.Up)
                {
                    continue;
                }

                IPInterfaceProperties properties = network.GetIPProperties();

                if (properties.GatewayAddresses.Count is 0)
                {
                    continue;
                }

                foreach (UnicastIPAddressInformation address in properties.UnicastAddresses)
                {
                    if (address.Address.AddressFamily is not AddressFamily.InterNetwork)
                    {
                        continue;
                    }

                    if (IPAddress.IsLoopback(address.Address))
                    {
                        continue;
                    }

                    if (address.IsDnsEligible is false)
                    {
                        mostSuitableIp ??= address;
                        continue;
                    }

                    // The best IP is the IP got from DHCP server
                    if (address.PrefixOrigin is not PrefixOrigin.Dhcp)
                    {
                        if (mostSuitableIp is null || mostSuitableIp.IsDnsEligible is false)
                        {
                            mostSuitableIp = address;
                        }

                        continue;
                    }

                    return address.Address.ToString();
                }
            }

            return mostSuitableIp is not null ? mostSuitableIp.Address.ToString() : "";
        }
        catch { }

        return "0.0.0.0";
    }

    /// <summary>
    /// 获得指定IP地址对应的MAC地址
    /// </summary>
    /// <remarks>MAC地址将以000000000000或00-00-00-00-00-00的形式返回，默认值全为零。</remarks>
    /// <param name="ipAddress">IP地址</param>
    /// <param name="isUseHorizontalBars">是否使用橫杠分隔</param>
    /// <returns>MAC地址</returns>
    public static string GetMacAddress(string ipAddress, bool isUseHorizontalBars = false)
    {
        try
        {
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (var face in interfaces)
            {
                UnicastIPAddressInformationCollection unicast = face.GetIPProperties().UnicastAddresses;

                foreach (UnicastIPAddressInformation cast in unicast)
                {
                    string value = cast.Address.ToString();

                    if (ipAddress.Equals(value))
                    {
                        string mac = BitConverter.ToString(face.GetPhysicalAddress().GetAddressBytes());
                        return isUseHorizontalBars ? mac : mac.Replace("-", "");
                    }
                }
            }
        }
        catch (Exception) { }

        return isUseHorizontalBars ? "00-00-00-00-00-00" : "000000000000";
    }
}