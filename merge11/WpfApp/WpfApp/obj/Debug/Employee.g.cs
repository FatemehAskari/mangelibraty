﻿#pragma checksum "..\..\Employee.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "8C311F7ED53D5F6C51423E89708621752AD59BF4BA352F164857FDFAE3A74185"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using WpfApp;


namespace WpfApp {
    
    
    /// <summary>
    /// Employee
    /// </summary>
    public partial class Employee : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 46 "..\..\Employee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\Employee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Balance;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\Employee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button changeInfo;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\Employee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bookList;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\Employee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button avlbBooks;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\Employee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button borrowed;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\Employee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button memberList;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\Employee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button delayedReturn;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\Employee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button delayedPayment;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\Employee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button login;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WpfApp;component/employee.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Employee.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 10 "..\..\Employee.xaml"
            ((WpfApp.Employee)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Employee_OnMouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btn = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\Employee.xaml"
            this.btn.Click += new System.Windows.RoutedEventHandler(this.btn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Balance = ((System.Windows.Controls.Button)(target));
            
            #line 72 "..\..\Employee.xaml"
            this.Balance.Click += new System.Windows.RoutedEventHandler(this.Show_Balance);
            
            #line default
            #line hidden
            return;
            case 4:
            this.changeInfo = ((System.Windows.Controls.Button)(target));
            
            #line 74 "..\..\Employee.xaml"
            this.changeInfo.Click += new System.Windows.RoutedEventHandler(this.Edit_Info);
            
            #line default
            #line hidden
            return;
            case 5:
            this.bookList = ((System.Windows.Controls.Button)(target));
            
            #line 76 "..\..\Employee.xaml"
            this.bookList.Click += new System.Windows.RoutedEventHandler(this.Book_List);
            
            #line default
            #line hidden
            return;
            case 6:
            this.avlbBooks = ((System.Windows.Controls.Button)(target));
            
            #line 78 "..\..\Employee.xaml"
            this.avlbBooks.Click += new System.Windows.RoutedEventHandler(this.Available);
            
            #line default
            #line hidden
            return;
            case 7:
            this.borrowed = ((System.Windows.Controls.Button)(target));
            
            #line 80 "..\..\Employee.xaml"
            this.borrowed.Click += new System.Windows.RoutedEventHandler(this.Borrowed);
            
            #line default
            #line hidden
            return;
            case 8:
            this.memberList = ((System.Windows.Controls.Button)(target));
            
            #line 86 "..\..\Employee.xaml"
            this.memberList.Click += new System.Windows.RoutedEventHandler(this.Member_List);
            
            #line default
            #line hidden
            return;
            case 9:
            this.delayedReturn = ((System.Windows.Controls.Button)(target));
            
            #line 89 "..\..\Employee.xaml"
            this.delayedReturn.Click += new System.Windows.RoutedEventHandler(this.Delayed_Return);
            
            #line default
            #line hidden
            return;
            case 10:
            this.delayedPayment = ((System.Windows.Controls.Button)(target));
            
            #line 92 "..\..\Employee.xaml"
            this.delayedPayment.Click += new System.Windows.RoutedEventHandler(this.Delayed_Pay);
            
            #line default
            #line hidden
            return;
            case 11:
            this.login = ((System.Windows.Controls.Button)(target));
            
            #line 96 "..\..\Employee.xaml"
            this.login.Click += new System.Windows.RoutedEventHandler(this.login_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

