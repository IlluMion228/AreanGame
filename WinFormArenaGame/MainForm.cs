using ArenaGame;
using ArenaGame.Heroes;
using ArenaGame.Weapons;


namespace WinFormArenaGame
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void gameNotification(GameEngine.NotificationArgs args)
        {
            TextBox tbAttacker = args.Attacker switch
            {
                Knight => tbKnight,
                Assassin => tbAssassin,
                Archer => tbArcher,
                Wizard => tbWizard,
                Tank => tbTank,
                _=> throw new ArgumentException("Unknown hero type")
            };

            tbAttacker.AppendText(
                $"{args.Attacker.Name} attacked {args.Defender.Name} with {Math.Round(args.Attack, 2)} and caused {Math.Round(args.Damage, 2)} damage.\r\n");

            DateTime dt = DateTime.Now;

            while (DateTime.Now - dt < TimeSpan.FromMilliseconds(300))
            {
                Application.DoEvents();
            }
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            lbWinner.Text = "";
            tbAssassin.Text = "";
            tbKnight.Text = "";

            lbWinner.Visible = false;

            GameEngine gameEngine = new GameEngine()
            {
                HeroA = new Knight("Knight", 10, 20, new Sword("Sword")),
                HeroB = new Assassin("Assassin", 10, 5, new Dagger("Dagger")),
                NotificationsCallBack = gameNotification
            };

            imgFight.Enabled = true;
            gameEngine.Fight();
            imgFight.Enabled = false;

            lbWinner.Text = $"And the winner is:\n{gameEngine.Winner}";
            lbWinner.Visible = true;
        }


        private void lbWinner_Click(object sender, EventArgs e)
        {

        }

        private void tbArcher_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            lbWinner.Text = "";
            tbArcher.Text = "";
            tbWizard.Text = "";

            lbWinner.Visible = false;

            GameEngine gameEngine = new GameEngine()
            {
                HeroA = new Archer("Archer", 25, 5, new Bow("Bow")),
                HeroB = new Wizard("Wizard", 30, 1, new MagicWand("MagicWand")),
                NotificationsCallBack = gameNotification
            };

            imgFight.Enabled = true;
            gameEngine.Fight();
            imgFight.Enabled = false;

            lbWinner.Text = $"And the winner is:\n{gameEngine.Winner}";
            lbWinner.Visible = true;
        }

        private void lbWinner_Click1(object sender, EventArgs e)
        {

        }
    }
}