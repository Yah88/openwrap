using NUnit.Framework;
using OpenWrap.Commands.Remote;
using OpenWrap.Commands.Remote.Messages;
using OpenWrap.Repositories;
using OpenWrap.Testing;
using Tests.Commands.contexts;

namespace Tests.Commands.remote.list.detailed
{
    class list_remote_with_fetch : command<ListRemoteCommand>
    {
        public list_remote_with_fetch()
        {
            given_remote_config("sauron");
            given_remote_factory(tokenFactory: token => new InMemoryRepository("Sauron's repository"));
            when_executing_command("-detailed");
        }

        [Test]
        public void entry_is_printed()
        {
            Results.ShouldHaveOne<RemoteRepositoryDetailedData>()
                .ToString().ShouldBe("  1 sauron     [fetch]\r\n" +
                                     "               name : Sauron's repository\r\n" +
                                     "               type : InMemoryRepository\r\n" +
                                     "               token: [memory]default\r\n"
                );
        }
    }
}