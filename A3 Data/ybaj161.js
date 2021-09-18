function LoadPage(index)
{
    PageArray=["Home","Staff","InstituteShop", "UserRegistration", "GuestBook"];
    lightcolorArray=["lightgreen","lightpink", "lightblue","lightcoral","lightyellow"];
    colorArray=["green","pink", "blue","red","yellow"];
    document.getElementById("Home").style.display = "none";
    document.getElementById("Staff").style.display = "none";
    document.getElementById("InstituteShop").style.display = "none";
    document.getElementById("UserRegistration").style.display = "none";
    document.getElementById("GuestBook").style.display = "none";
    document.getElementById(PageArray[index]).style.display ="block";
    document.getElementById("navBar").style.backgroundColor = lightcolorArray[index];
    document.getElementById("navBar").style.borderColor = colorArray[index];


}