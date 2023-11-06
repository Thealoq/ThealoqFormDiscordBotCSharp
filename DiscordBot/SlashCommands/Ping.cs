using DSharpPlus.SlashCommands;
using DSharpPlus.Entities;
using System.Threading.Tasks;
using DSharpPlus;

namespace SlashCommands
{
    internal class Ping : ApplicationCommandModule
    {
        [SlashCommand("hello", "Greet the bot")]
        public async Task HelloCommand(InteractionContext ctx)
        {
            await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().WithContent("Hello, World!"));
        }
    }
}