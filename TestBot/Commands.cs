using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Interactivity;

namespace TestBot
{
    
    public class Commands
    {
        [Command("hi")]
        public async Task Hi (CommandContext ctx)
        {
            await ctx.RespondAsync($"I hate pickles.");
            var interactivity = ctx.Client.GetInteractivityModule();
            var msg = await interactivity.WaitForMessageAsync(xm => xm.Author.Id == ctx.User.Id && xm.Content.ToLower() == "m8", TimeSpan.FromMinutes(1));
            if (msg != null)
            {
                await ctx.RespondAsync($"fuck off McFat");
            }
            
        }

        [Command("random")]
        public async Task Random(CommandContext ctx, int min, int max)
        {
            var rnd = new Random();
            await ctx.RespondAsync($"🎲 Your random number is: {rnd.Next(min, max)}");
        }
    }
}
