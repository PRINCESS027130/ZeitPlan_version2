using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ZeitPlan.Views.Admin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Degree_Detail : ContentPage
    {
        public Degree_Detail(TBL_DEGREE de)
        {
            InitializeComponent();
            LoadData(de);

        }
        async void LoadData(TBL_DEGREE de)
        {
            try
            {
                var Department = (await App.firebaseDatabase.Child("TBL_DEPARTMENT").OnceAsync<TBL_DEPARTMENT>()).FirstOrDefault(x => x.Object.DEPARTMENT_ID == de.DEPARTMENT_FID);
                DegreeName.Text = de.DEGREE_NAME;
                DepartmentFID.Text = de.DEPARTMENT_FID.ToString();
            }
            catch (Exception ex)
            {
                //LoadingInd.IsRunning = false;
                await DisplayAlert("Error", "Something went wrong Please try again later.\nError:" + ex.Message, "ok");
                return;

            }
        }
    }
}