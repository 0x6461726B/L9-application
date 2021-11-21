using System;
using System.Windows.Forms;
using PoniLCU;


namespace WindowsFormsApp1
{
    public partial class L9 : Form
    {

        public L9()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            LeagueClient leagueClient = new LeagueClient();
            while (!leagueClient.IsConnected)
            {
               // continue;

                System.Windows.Forms.MessageBox.Show("Start league of legends first!");
                System.Environment.Exit(0);
            }
            leagueClient.Subscribe("/lol-gameflow/v1/gameflow-phase", GameFlowPhase);
           // leagueClient.Subscribe("/lol-champ-select/v1/session", Players);

        }


        private void button1_Click(object sender, EventArgs e)
        {
            string firstVal = textBox1.Text;
            Console.WriteLine(firstVal);
            LeagueClient leagueClient = new LeagueClient();
            string body = "{\"profileIconId\": " + Convert.ToInt32(firstVal) + "}";
            leagueClient.Request("put", "/lol-summoner/v1/current-summoner/icon", body);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public void label1_Click(object sender, EventArgs e)
        {

        }
        private void GameFlowPhase(OnWebsocketEventArgs obj)
        {
            LeagueClient leagueClient = new LeagueClient();
            label1.Invoke(new Action(() =>
            {
                label1.Text = Convert.ToString(obj.Data);
            }));

            if (obj.Data == "ReadyCheck")
            {
                if (checkBox1.Checked == true)
                {
                    leagueClient.Request("POST", "/lol-matchmaking/v1/ready-check/accept", " ");



                }

             }


            



        }


        



            private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {

            System.Windows.Forms.MessageBox.Show("L9 HACKED LOL!!");


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {



        }

        private void button3_Click(object sender, EventArgs e)
        {
            LeagueClient leagueClient = new LeagueClient();
            string status = textBox2.Text ;
            Console.WriteLine(status);
            string body = "{\"statusMessage\": " + "\"" +status + "\"" + "}";
            leagueClient.Request("put", "/lol-chat/v1/me", body);
            Console.WriteLine(body);
        }
    }
}
