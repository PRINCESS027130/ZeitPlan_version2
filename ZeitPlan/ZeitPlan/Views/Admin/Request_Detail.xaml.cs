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
    public partial class Request_Detail : ContentPage
    {
        public Request_Detail(TBL_REQUEST_PORTAL r)
        {
            InitializeComponent();
            LoadData(r);
           

        }
        async void LoadData(TBL_REQUEST_PORTAL r)
        {
            try
            {
                var Student = (await App.firebaseDatabase.Child("TBL_STUDENT").OnceAsync<TBL_STUDENT>()).FirstOrDefault(x => x.Object.STUDENT_ID == r.Student_FID);
                RequestID.Text = r.REQUEST_PORTAL_ID.ToString();

                DepartmentName.Text = r.DEPARTMENT_FID.ToString();
                StudentName.Text = r.Student_FID.ToString();
                Type.Text = r.TYPE.ToString();
                Message.Text = r.REQUEST_MESSAGE;
                Status.Text = "Pending";
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