using DSharpPlus.SlashCommands;
using DSharpPlus.Entities;
using System.Threading.Tasks;

internal class SlashCommands
{
    public class PingCommands : ApplicationCommandModule
    {
        [SlashCommand("ping", "Ping the bot")]
        public async Task PingCommand(InteractionContext ctx)
        {
            await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().WithContent("Pong!"));
        }
    }
}