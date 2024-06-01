namespace Domain.Entities
{
    public class Contacts
    {
        public int Id { get; set; }
        public string resourceName { get; set; }
        public string etag { get; set; }

        //names
        public string Name { get; set; }
        public string Given_Name { get; set; }
        public string Additional_Name { get; set; }
        public string Family_Name { get; set; }
        public string Yomi_Name { get; set; }
        public string Given_Name_Yomi { get; set; }
        public string Additional_Name_Yomi { get; set; }
        public string Family_Name_Yomi { get; set; }
        public string Name_Prefix { get; set; }
        public string Name_Suffix { get; set; }
        public string Initials { get; set; }
        public string Nickname { get; set; }
        public string Short_Name { get; set; }
        public string Maiden_Name { get; set; }

        //subject
        public string Birthday { get; set; }
        public string Gender { get; set; }
        public string Location { get; set; }
        public string Billing_Information { get; set; }
        public string Directory_Server { get; set; }
        public string Mileage { get; set; }
        public string Occupation { get; set; }
        public string Hobby { get; set; }
        public string Sensitivity { get; set; }
        public string Priority { get; set; }
        public string Subject { get; set; }
        public string Notes { get; set; }
        public string Language { get; set; }
        public string Photo { get; set; }
        public string Group_Membership { get; set; }

        //emails
        public string E_mail_1_Type { get; set; }
        public string E_mail_1_Value { get; set; }

        //phones
        public string Phone_1_Type { get; set; }
        public string Phone_1_Value { get; set; }
        public string Phone_2_Type { get; set; }
        public string Phone_2_Value { get; set; }
        public string Phone_3_Type { get; set; }
        public string Phone_3_Value { get; set; }
        public string Phone_4_Type { get; set; }
        public string Phone_4_Value { get; set; }
        public string Phone_5_Type { get; set; }
        public string Phone_5_Value { get; set; }
        public string Phone_6_Type { get; set; }
        public string Phone_6_Value { get; set; }

        //address
        public string Address_1_Type { get; set; }
        public string Address_1_Formatted { get; set; }
        public string Address_1_Street { get; set; }
        public string Address_1_City { get; set; }
        public string Address_1_PO_Box { get; set; }
        public string Address_1_Region { get; set; }
        public string Address_1_Postal_Code { get; set; }
        public string Address_1_Country { get; set; }
        public string Address_1_Extended_Address { get; set; }
        public string Address_2_Type { get; set; }
        public string Address_2_Formatted { get; set; }
        public string Address_2_Street { get; set; }
        public string Address_2_City { get; set; }
        public string Address_2_PO_Box { get; set; }
        public string Address_2_Region { get; set; }
        public string Address_2_Postal_Code { get; set; }
        public string Address_2_Country { get; set; }
        public string Address_2_Extended_Address { get; set; }

        //organizations
        public string Organization_1_Type { get; set; }
        public string Organization_1_Name { get; set; }
        public string Organization_1_Yomi_Name { get; set; }
        public string Organization_1_Title { get; set; }
        public string Organization_1_Department { get; set; }
        public string Organization_1_Symbol { get; set; }
        public string Organization_1_Location { get; set; }
        public string Organization_1_Job_Description { get; set; }
        public bool isActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? SyncDate { get; set; }
    }
}
