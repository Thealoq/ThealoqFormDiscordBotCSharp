using System;
using System.Windows.Forms;
using DSharpPlus;
using DSharpPlus.EventArgs;
using DSharpPlus.SlashCommands;
using System.Threading.Tasks;
using static SlashCommands.Ping;
using DSharpPlus.Entities;
using DSharpPlus.AsyncEvents;

namespace DiscordBot
{
    public partial class Form1 : Form
    {
        public static DiscordClient client { get; set; }
        string DiscordToken = null;
        bool Status = false;

        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            DiscordToken = textBox1.Text;
            Status = true;
            Task task = ConnectAsync();
        }

        private async Task ConnectAsync()
        {
            try
            {
                var discord = new DiscordClient(new DiscordConfiguration()
                {
                    Token = DiscordToken,
                    TokenType = TokenType.Bot,
                    Intents = DiscordIntents.All
                });

                discord.MessageCreated += ClientMessageCreated;
                discord.Ready += OnClientReady;

                var slash = discord.UseSlashCommands();
                slash.RegisterCommands<SlashCommands.Ping>();

                await discord.ConnectAsync();

                client = discord;
                await Task.Delay(-1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message, "Hata");
            }
        }

        private AsyncEventHandler<DiscordClient, MessageCreateEventArgs> ClientMessageCreated()
        {
            throw new NotImplementedException();
        }

        private Task ClientMessageCreated(DiscordClient client, MessageCreateEventArgs e)
        {
            if (e.Message.Content.ToLower() == "ping")
            {
                e.Message.RespondAsync("Pong!");
            }
            return Task.CompletedTask;
        }

        private Task OnClientReady(DiscordClient client, ReadyEventArgs e)
        {
            button1.BackColor = System.Drawing.Color.Green;
            panel1.BackColor = System.Drawing.Color.Green;
            string UserName = client.CurrentUser.Username;
            label1.Invoke((Action)(() =>
            {
                label1.Text = UserName;
            }));

            label2.Invoke((Action)(() =>
            {
                label2.Text = "Status: Connect";
            }));

            string avatarUrl = client.CurrentUser.GetAvatarUrl(ImageFormat.Png);
            pictureBox1.Load(avatarUrl);
            return Task.CompletedTask;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.UseSystemPasswordChar = true;

        }
    }
}
