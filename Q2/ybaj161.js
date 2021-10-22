function LoadPage() {
  LoadDailyTable();
  LoadInfographic1();
  LoadInfographic2();
  LoadStats();
}
function LoadDailyTable() {
  const DCDT = document.getElementById("tabTable");
  const VID = document.getElementById("VID");

  fetch("https://cws.auckland.ac.nz/Qz2021JGC/api/Version")
    .then((res) => res.json())
    .then((data) => (VID.innerHTML += ` ${data}`));

  fetch("https://cws.auckland.ac.nz/Qz2021JGC/api/CaseCounts")
    .then((res) => res.json())
    .then((data) => {
      let tableString = "<table><tr><th>Dates</th>";
      Object.entries(data).forEach(
        ([key, value]) => (tableString += `<td>${key}</td>`)
      );
      tableString += "</tr><tr><th>Count</th>";
      Object.entries(data).forEach(
        ([key, value]) => (tableString += `<td>${value}</td>`)
      );
      tableString += "</tr></table>";
      DCDT.innerHTML = tableString;
    });
}
function LoadInfographic1() {
  const SC = document.getElementById("SvgChart");
  let svgString =
    '<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 478 300"><defs>';
  fetch("https://cws.auckland.ac.nz/Qz2021JGC/api/PersonIcon")
    .then((res) => res.text())
    .then((rawSvg) =>
      new DOMParser().parseFromString(rawSvg, "application/xml")
    )
    .then((xmlSvg) => {
      svgString += `${xmlSvg.documentElement.innerHTML} </defs>`;
    });

  fetch("https://cws.auckland.ac.nz/Qz2021JGC/api/CaseCounts")
    .then((res) => res.json())
    .then((data) => {
      var y = 17.9;
      var TextY = 33;
      Object.entries(data)
        .slice(Object.entries(data).length - 10)
        .forEach(([key, value]) => {
          var x = 45;
          svgString += `<text font-size="8.3" font-family="Verdana" font-weight="900" x="1" y="${TextY}">${key}</text>`;
          TextY += 24.45;
          for (var i = 0; i < value; i++) {
            svgString += `<use
                x="${x}"
                y="${y}"
                xlink:href="#person"
                height="20"
                width="50"
              />`;
            x += 20.5;
          }
          y += 24.275;
        });
      svgString += `<text font-size="5.8" font-family="Verdana" font-weight="900" x="1" y="8">Last Ten Days at a Glance</text>`;

      svgString += `</svg>`;
      SC.innerHTML = svgString;
    });
}

function LoadInfographic2() {
  const SC = document.getElementById("SvgChart2");
  fetch("https://cws.auckland.ac.nz/Qz2021JGC/api/CaseCounts")
    .then((res) => res.json())
    .then((data) => {
      var x = 10;
      var y = 390;
      var diff = 0;
      svgString = `<svg xmlns="http://www.w3.org/2000/svg" viewBox ="0 0 400 200"><rect width="400" height="200" fill="white" stroke="black" id="backDrop"/><text x="5" y="15" font-family="verdana" font-size="8.8" font-weight="900">Daily Case Graph</text><path d="m 10 190 `;
      Object.entries(data).forEach(([key, value]) => {
        svgString += `h 0.75 V${190 - value} `;
      });
      svgString += `" stroke="black" stroke-width="0.55" fill="none"/>
      <text x="10" y="195" font-family="verdana" font-size="3">${
        Object.entries(data)[0][0]
      }</text>
      <text x="375" y="195" font-family="verdana" font-size="3">${
        Object.entries(data)[Object.entries(data).length - 1][0]
      }</text>
      </svg>`;
      SC.innerHTML += svgString;
    });
}
async function LoadStats() {
  const Statistician = document.getElementById("Statistician");

  let cStatPromise = await fetch(
    "https://cws.auckland.ac.nz/Qz2021JGC/api/Statistician"
  );
  let cStat = await cStatPromise.json();
  const URL = `https://unidirectory.auckland.ac.nz/people/vcard/${cStat.upi}`;
  let vCardP = await fetch(`http://localhost:5050/proxy?url=${URL}`);
  let vCard = await vCardP.text();
  vcardList = vCard.trim().split("\n");
  let org = vcardList.filter((v) => v.includes("ORG"))[0];
  let title = vcardList.filter((v) => v.includes("TITLE"))[0];
  let add = vcardList.filter((v) => v.includes("ADR"))[0];
  let statStr = `
  <div class="StatPerson" id="1">
          <img
            src="https://unidirectory.auckland.ac.nz/people/imageraw/${
              cStat.upi
            }/${cStat.imageId}/biggest"
            alt="${vcardList.filter((v) => v.includes("FN"))[0].substring(3)}"
          />
          <div class="SPersonD">
            <h1>${vcardList
              .filter((v) => v.includes("FN"))[0]
              .substring(3)}</h1>
            <p>${org ? org : "ORG: No Org"}</p>
            <p>${title ? title : "TITLE: No title"}</p>
            <p>${vcardList.filter((v) => v.includes("REV"))[0]}</p>
            <p>Email: <a href="mailto:${vcardList
              .filter((v) => v.includes("EMAIL"))[0]
              .substring(25)}">${vcardList
    .filter((v) => v.includes("EMAIL"))[0]
    .substring(25)}</a></p>
<p>           Tel:  <a href="tel:${vcardList
    .filter((v) => v.includes("TEL"))[0]
    .substring(20)}">${vcardList
    .filter((v) => v.includes("TEL"))[0]
    .substring(20)}</a></p>
            <p>Address: ${add ? add.substring(16) : "Address: No Address"}</p>
              <a href="http://localhost:5050/proxy?url=${URL}">Click Here to Download the Vcard</a>
          </div>
        </div>
        `;
  Statistician.innerHTML = statStr;
}
