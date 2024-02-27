using Answer_5.UML_diagram_Class;

class Program
{
    static void Main()
    {
        Doctor doctor = new Doctor
        {
            Name = "Sharmin Shila",
            HospitalName = "Square Hospital",
            PracticeNumber = "12345"
        };

        Pharmacist pharmacist = new Pharmacist
        {
            Name = "Abu Saleh",
            HospitalName = "Square Pharmacy",
            PharmacistNumber = "54321"
        };

        bool doctorLoginResult = doctor.Login("docUser", "docPass");
        Console.WriteLine($"Doctor Login Result: {doctorLoginResult}");

        doctor.CreatePrescription(1001);

        bool pharmacistLoginResult = pharmacist.Login("pharmUser", "pharmPass");
        Console.WriteLine($"Pharmacist Login Result: {pharmacistLoginResult}");

        pharmacist.DispenseMedications(2001);
    }
}
