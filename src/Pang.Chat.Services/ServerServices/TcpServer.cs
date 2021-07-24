using Microsoft.Extensions.Hosting;
using SuperSocket.ProtoBase;
using SuperSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Pang.Chat.DAO.Sessions;
using SuperSocket.SessionContainer;

namespace Pang.Chat.Services.ServerServices
{
    public class TcpServer : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var tcpHost = SuperSocketHostBuilder.Create<StringPackageInfo, CommandLinePipelineFilter>()
                .ConfigureSuperSocket(opt =>
                {
                    opt.AddListener(new ListenOptions()
                    {
                        Ip = "Any",
                        Port = 10800
                    });
                })
                .UseClearIdleSession()
                .UseSession<ChatTcpSession>()
                .UseSessionHandler(async (session) =>
                {
                    await Task.CompletedTask;
                }, async (session, v) =>
                {
                    await Task.CompletedTask;
                })
                .UsePackageHandler(async (session, package) =>
                {
                    await Task.CompletedTask;
                })
                .UseInProcSessionContainer()
                .UseMiddleware<InProcSessionContainerMiddleware>()
                .UseInProcSessionContainer()
                .BuildAsServer();

            await tcpHost.StartAsync();
        }
    }
}
