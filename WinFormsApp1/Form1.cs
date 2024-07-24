using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;

namespace HebrewDate
{

    public partial class Form1 : Form
    {
        private const string PATH = ".//dates.xml";
        private XDocument _activeDoc;

        public Form1()
        {
            InitializeComponent();
            EnsureFile();
            _activeDoc = XDocument.Load(PATH);

        }
        private void EnsureFile()
        {
            if (!File.Exists(PATH))
            {
                var root = new XDocument(new XElement("Queries"));
                root.Save(PATH);
            }
        }

        private string GenerateMessageDayMonth()
        {
            string dayMonth = comboBox2.SelectedItem.ToString();
            string dayMonthMessage = dayMonth switch
            {
                "1" => "יום אחד",
                "2" => "שני ימים",
                "3" => "שלשה ימים",
                "4" => "ארבעה ימים",
                "5" => "חמשה ימים",
                "6" => "ששה ימים",
                "7" => "שבעה ימים",
                "8" => "שמנה ימים",
                "9" => "תשעה ימים",
                "10" => "עשרה ימים",
                "11" => "אחד עשר יום",
                "12" => "שנים עשר יום",
                "13" => "שלשה עשר יום",
                "14" => "ארבעה עשר יום",
                "15" => "חמשה עשר יום",
                "16" => "ששה עשר יום",
                "17" => "שבעה עשר יום",
                "18" => "שמנה עשר יום",
                "19" => "תשעה עשר יום",
                "20" => "עשרים יום",
                "21" => "אחד ועשרים יום",
                "22" => "שנים ועשרים יום",
                "23" => "שלשה ועשרים יום",
                "24" => "ארבעה ועשרים יום",
                "25" => "חמשה ועשרים יום",
                "26" => "ששה ועשרים יום",
                "27" => "שבעה ועשרים יום",
                "28" => "שמנה ועשרים יום",
                "29" => "תשעה ועשרים יום",
                "30" => "יום שלשים לחדש פלוני שהוא ראש חדש פלוני"
            };
            return dayMonthMessage;
        }
        
        private string GenerateYearMessage()
        {
            string year = comboBox4.SelectedItem.ToString();
            string yearMessage = year switch
            {
                "תשפ\"ד" => "שמנים וארבע",
                "תשפ\"ה" => "שמנים וחמש",
                "תשפ\"ן" => "שמנים ושש",
                "תשפ\"ז" => "שמנים ושבע",
                "תשפ\"ח" => "שמנים ושמנה",
                "תשפ\"ט" => "שמנים ותשע",
                "תש\"צ" => "תשעים",
                "תשצ\"א" => "תשעים ואחת",
                "תשצ\"ב" => "תשעים ושתים",
            };
            return yearMessage;
        }
        private  string Result()
        {
            string dayMessage = comboBox1.SelectedItem.ToString();
            string dayMonthMessage = GenerateMessageDayMonth();
            string yearMessage = GenerateYearMessage();
            string month = comboBox3.SelectedItem.ToString();
            string result = $"לבריאת העולם {yearMessage}בשנת חמשת אלפים ושבע מאות ו {month} לירח {dayMonthMessage} {dayMessage}ב";
            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XElement root = _activeDoc.Root;
            XElement dayOfWeek = new XElement("Day", comboBox1.SelectedItem.ToString());
            XElement dayOfMonth = new XElement("DayMonth", comboBox2.SelectedItem.ToString());
            XElement monthName = new XElement("Month", comboBox3.SelectedItem.ToString());
            XElement year = new XElement("Year", comboBox4.SelectedItem.ToString());
            XElement result = new XElement("Result", Result());
            XElement query = new XElement("Query", dayOfWeek, dayOfMonth, monthName, year, result);
            root.Add(query);
            _activeDoc.Save(PATH);

            MessageBox.Show(Result());
        }
    }
}
