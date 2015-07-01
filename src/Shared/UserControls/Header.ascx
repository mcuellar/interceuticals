<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="Interceuticals.Shared.UserControls.Header" %>
<header id="banner" class="body"> 
    <section id="phone">
    <img alt="Call Us at 888-686-2698" src="/interceuticals/Images/Shared/PhoneNumber.png"/>
    </section>
    
    <nav>
        <ul id="mainNav"> 
            <li class="active"><a href="#" onclick="javascript:redirectTo('http://www.interceuticals.com/interceuticals/Default.aspx')">Home</a></li>
            <li><a href="#" onclick="javascript:redirectTo('http://www.betterwomannow.com/Home.aspx')">BetterWOMAN</a>
                <ul>
                    <li><a href="#" onclick="javascript:redirectTo('http://www.interceuticals.com/interceuticals/Product/Default.aspx?site=bw')">Shop</a></li>
                    <li><a href="#" onclick="javascript:redirectTo('http://www.betterwomannow.com/Default.aspx')">More Info</a></li>
                </ul>   
            </li> 
            <li><a href="#" onclick="javascript:redirectTo('http://www.bettermannow.com/Home.aspx')">BetterMAN</a>
                <ul>
                    <li><a href="#" onclick="javascript:redirectTo('http://www.interceuticals.com/interceuticals/Product/Default.aspx')">Shop</a></li>
                    <li><a href="#" onclick="javascript:redirectTo('http://www.bettermannow.com/Home.aspx')">More Info</a></li>
                </ul>           
            </li>  
            <li><a href="#" onclick="javascript:redirectTo('http://www.interceuticals.com/interceuticals/WebContent/ContactUs.aspx')">Contact Us</a></li>
        </ul>
    </nav>  
</header>

