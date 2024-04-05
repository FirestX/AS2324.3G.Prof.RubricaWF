namespace AS2324._3G.Prof.RubricaWF
{
    public partial class Form1 : Form
    {
        const int nMaxContatti = 100;

        int nRecordInseriti = 0;

        Person[] people = new Person[nMaxContatti];

        public Form1()
        {
            InitializeComponent();
        }

        private void btnRicerca_Click(object sender, EventArgs e)
        {
            if (cmbRicerca.Text == "")
                MessageBox.Show("E' necessario definire il campo di ricerca.");
        }

        private void btnAggiungi_Click(object sender, EventArgs e)
        {
            if (txtCognome.Text.Length == 0 ||
                txtNome.Text.Length == 0 ||
                txtNickName.Text.Length == 0)
            {
                MessageBox.Show("Dati obbligatori non inseriti non è possibile aggiungere il record");
                return;
            }

            if (cmbSimpatia.Text.Length > 0)
            {

                if (txtAnnoNascita.Text.Length > 0)
                {
                    int yearOfBirth = Convert.ToInt32(txtAnnoNascita.Text);
                    int sympathy = Convert.ToInt32(cmbSimpatia.Text);
                    people[nRecordInseriti] = new(txtCognome.Text, txtNome.Text, txtEmail.Text, txtNickName.Text,
                        yearOfBirth, sympathy);
                }
            }

            nRecordInseriti++;

        }

        private void btnElenca_Click(object sender, EventArgs e)
        {
            lstElenco.Items.Clear();
            lstElenco.Items.Add("Elenco dei nominativi inseriti");

            lstElenco.Items.Add("cognome              nome                 email                nickname  simpatia annoNascita");
            for (int i = 0; i < nRecordInseriti; i++)
            {
                lstElenco.Items.Add(people[i].PrintInfo());
            }
        }
    }
    class Person
    {
        public string Surname { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Nickname { get; private set; }
        public int YearOfBirth { get; private set; }
        public int Sympathy { get; private set; }
        public Person(string surname, string name, string email, string nickname, int yearOfBirth, int sympathy)
        {
            Surname = surname;
            Name = name;
            Email = email;
            Nickname = nickname;
            YearOfBirth = yearOfBirth;
            Sympathy = sympathy;
        }
        public string PrintInfo()
        {
            return $"{Surname.PadRight(20).Substring(0, 20)} {Name.PadRight(20).Substring(0, 20)} {Email?.PadRight(20)} {Nickname.PadRight(10).Substring(0, 10)} {Sympathy} {YearOfBirth}";
        }
    }
}
