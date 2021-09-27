var modal = document.getElementById("myModal");
var span = document.getElementsByClassName("close")[0];
span.onclick = function () {
  modal.style.display = "none";
};
window.onclick = function (event) {
  if (event.target == modal) {
    modal.style.display = "none";
  }
};

function listStaffVcard() {
  var StaffContainer = document.getElementById("StaffContainer");
  fetch("http://localhost:5000/api/GetAllStaff", {
    headers: { Accept: "application/json" },
  })
    .then((response) => response.json())
    .then((StaffListData) =>
      StaffListData.forEach((element) => {
        // for each started
        fetch("http://localhost:5000/api/GetCard/" + element.id, {
          headers: { Accept: "text/vcard; charset=utf-8" },
        })
          .then((response) => response.text())
          .then((CardData) => {
            var datalist = CardData.split(`\r\n`);
            StaffContainer.innerHTML += `<div class="staffList">
        <img class="StaffPhoto" src=
         'http://localhost:5000/api/GetStaffPhoto/${element.id}'
        
         alt="StaffPhoto" />
        <h3>${datalist[3].slice(3)}</h3>
        <a href="mailto:${datalist[6].slice(16)}"
          >WorkEmail: ${datalist[6].slice(16)}</a
        >
        <br />
        <a href="TEL:${datalist[7].slice(4)}">Phone Number:${datalist[7].slice(
              4
            )}</a>
        <br />
        <p>
          Research Interests: ${datalist[9].slice(11)}
        </p>
        <a class="addressBook" style="float: right; padding: 10"href="http://localhost:5000/api/GetCard/${
          element.id
        }">Save to Address Book</a>
      </div>`;
          });
      })
    );
}
function LoadStoreItems() {
  var ItemContainer = document.getElementById("InstituteShopItems");
  // for each started
  fetch("http://localhost:5000/api/GetItems", {
    headers: { Accept: "text/json; charset=utf-8" },
  })
    .then((response) => response.json())
    .then((ItemData) => {
      ItemContainer.innerHTML = "";
      ItemData.forEach((item) => {
        ItemContainer.innerHTML += `<div class='InstituteShopList'>
      <img src='http://localhost:5000/api/GetItemPhoto/${item.id}' alt='${item.name} Image' />
      <div class='ItemInfo'>
      <h2 id='Item${item.id}'>${item.name}</h2>
      <h3>$${item.price}</h3>
      <p>${item.description}</p>
      </div>
      <button id='${item.id}' onClick="BuyItem(id)">Buy</button>
    </div>`;
      });
    });
}
function searchItems(value) {
  var ItemContainer = document.getElementById("InstituteShopItems");
  const ItemfetchPromise = fetch(
    `http://localhost:5000/api/GetItems/${value}`,
    {
      headers: { Accept: "text/json; charset=utf-8" },
    }
  );
  const ItemStreamPromise = ItemfetchPromise.then((response) =>
    response.json()
  );
  ItemStreamPromise.then((ItemData) => {
    ItemContainer.innerHTML = "";
    ItemData.forEach((item) => {
      ItemContainer.innerHTML += `<div class='InstituteShopList'>
      <img src='http://localhost:5000/api/GetItemPhoto/${item.id}' alt='${item.name} Image' />
      <div class='ItemInfo'>
      <h2>${item.name}</h2>
      <h3>$${item.price}</h3>
      <p>${item.description}</p>
      </div>
      <button id='${item.id}' onClick="BuyItem(id)">Buy</button>
    </div>`;
    });
  });
}
function loginPage() {
  document.getElementById("Home").style.display = "none";
  document.getElementById("Staff").style.display = "none";
  document.getElementById("InstituteShop").style.display = "none";
  document.getElementById("UserRegistration").style.display = "none";
  document.getElementById("GuestBook").style.display = "none";
  localStorage.clear();
  document.getElementById("LoginPage").style.display = "Block";
  document.getElementById("Message").style.display = "none";
}
function Login(username, Password) {
  const status = document.getElementById("Status");
  fetch("http://localhost:5000/api/GetVersionA", {
    headers: {
      Accept: "text/plain",
      Authorization: `Basic ${btoa(`${username}:${Password}`)}`,
    },
  })
    .then((response) => {
      if (response.ok) {
        localStorage.setItem("id", btoa(`${username}:${Password}`));
        status.innerHTML = `Status: Logged in as ${username}`;

        document.getElementById("LogOutbutton").style.display = "Block";
        document.getElementById("Loginbutton").style.display = "none";
        document.getElementById("Message").style.display = "none";

        LoadPage(0);
        alert(`You are now Logged in as ${username}`);
      } else {
        document.getElementById("Message").style.display = "block";
        document.getElementById(
          "Message"
        ).innerHTML = `<h1>${response.statusText}</h1>`;
      }
    })
    .catch();
}
function logout() {
  document.getElementById("LogOutbutton").style.display = "none";
  document.getElementById("Loginbutton").style.display = "Block";

  localStorage.removeItem("id");
  document.getElementById("Status").innerHTML = `Status: Logged Out`;
}
function BuyItem(id) {
  const data = localStorage.getItem("id");
  if (data === null) {
    loginPage();
    alert("Please Login before making a purchase");
  }
  constfetchPromise = fetch(
    `http://localhost:5000/api/PurchaseSingleItem/${id}`,
    {
      headers: {
        "Content-Type": "text/plain",
        Authorization: `Basic ${data}`,
      },
    }
  );

  constfetchPromise.then((response) => {
    if (response.status == 201) {
      document.getElementById(
        "purchaseMessage"
      ).innerHTML = `Thank you for purchasing the ${
        document.getElementById(`Item${id}`).innerHTML
      } Item`;
      modal.style.display = "block";
    } else {
      console.log(response.status);
    }
  });
}
function LoadPage(index) {
  PageArray = [
    "Home",
    "Staff",
    "InstituteShop",
    "UserRegistration",
    "GuestBook",
  ];
  lightcolorArray = [
    "lightgreen",
    "lightpink",
    "lightblue",
    "lightcoral",
    "lightyellow",
  ];
  colorArray = ["green", "pink", "blue", "red", "yellow"];
  document.getElementById("Home").style.display = "none";
  document.getElementById("Staff").style.display = "none";
  document.getElementById("InstituteShop").style.display = "none";
  document.getElementById("UserRegistration").style.display = "none";
  document.getElementById("GuestBook").style.display = "none";
  document.getElementById("LoginPage").style.display = "none";

  document.getElementById(PageArray[index]).style.display = "block";
  document.getElementById("navBar").style.backgroundColor =
    lightcolorArray[index];
  document.getElementById("navBar").style.borderColor = colorArray[index];

  if (index === 1) {
    listStaffVcard();
  }
  if (index === 2) {
    LoadStoreItems();
  }
}
function registerUser(username, password, address) {
  fetch("http://localhost:5000/api/Register", {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({
      userName: username,
      password: password,
      address: address,
    }),
  }).then((response) => {
    alert(`${username} of address ${address} is now a registered User`);
    LoadPage(0);
  });
}
function submitComment(comment1, name1) {
  fetch("http://localhost:5000/api/WriteComment", {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({
      comment: comment1,
      name: name1,
    }),
  }).then(() => {
    const x = document.getElementById("CommentSection");
    x.src = x.src;
  });
}
