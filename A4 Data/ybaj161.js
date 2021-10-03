async function MakeSvg() {
  const secretGraph = document.getElementById("svgDefs");
  const graph = document.getElementById("secretGraph");
  const iconSymbol = async () => {
    await fetch("http://localhost:5000/api/GetIcon", {
      headers: {
        "Content-Type": "text/xml",
      },
    })
      .then((res) => res.text())
      .then((svgStr) =>
        new DOMParser().parseFromString(svgStr, "application/xml")
      )
      .then((xmlSvg) => {
        xmlSvg.firstChild.firstChild.firstChild.setAttribute("fill", "#FFD800");
        secretGraph.innerHTML += xmlSvg.documentElement.innerHTML;
      });
  };
  await iconSymbol();
  var res = await fetch("http://localhost:5000/api/S")
  var arrayDatastr =  await res.text();
  var arrayData = arrayDatastr.replace(/[\r\n\[\]\s]/gm, "").split(",").map((i) => Number(i));
  let dxY = 2;
  let dxY2 = 21;
  
  let fontY = 14.5;
  for (i = 0; i < arrayData.length; i++)
  {
    graph.innerHTML += `<text x="4" y="${fontY}" class="yLabel" font-family="Arial">${i+1}</text>`
    fontY += 22.5;
  }

  arrayData.forEach(number => {    
  
    let dxX = 12.8;
    for (let x = 0;x < number; x++)
    {
      if (x % 2 === 0)
      {
        graph.innerHTML += `<use
        x="${dxX}"
        y="${dxY}"
        id="drop"
        xlink:href="#sDrop"
        height="18"
        width="18"
      />`
      dxX += 8.99; 

      }
      else
      {
        graph.innerHTML += `<use
        x="${dxX}"
        y="2"
        id="drop2"
        xlink:href="#sDrop"
        height="18"
        width="18"
        transform="scale(1 -1) translate(0 -${dxY2})"
      />`;
      dxX += 8.99; 


      }

    }
    dxY += 22.45;
    dxY2 += 22.5;

  });
 
}
