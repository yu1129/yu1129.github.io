const url = "https://raw.githubusercontent.com/yu1129/hard/main/Hw6_ipadAir.json";

let xhr = new XMLHttpRequest();
let ipadArray;
let colors, price, storage, network, imgs, productimgs;
let colorsList = [];
let storageList = [];
let networkList = []
let styles;

xhr.onload = function(){
    ipadArray = JSON.parse(this.responseText);
    createHE(ipadArray);
}
xhr.open("GET", url);

xhr.send();

window.onload = function (){
    let left = document.querySelector(".left");
    let bundles = document.querySelectorAll(".bundle");
    let bundlestorage = document.querySelectorAll(".bundlestorage");
    let bundleconnect = document.querySelectorAll(".bundleconnect");
    let bundlestyle = document.querySelectorAll(".bundlestyle");
    let clickcolor, clickstorage, clickconnect, clickstyle;
    
    bundles.forEach((item, index) => {
        item.addEventListener("click", function(event){
            // console.log(item.innerText);
            if (item != clickcolor && clickcolor != undefined){
                clickcolor.removeAttribute("style", "border: 3px solid #0775E4;");
            }
            item.setAttribute("style", "border: 3px solid #0775E4;");
            left.innerHTML = "";
            left.innerHTML = `<img src = 'Hw6_iPadAir/${productimgs[index]}' alt = ${colors[index]}>`;
            clickcolor = item;
        });
    });

    bundlestorage.forEach((item, index) => {
        item.addEventListener("click", function(event){
            if (item != clickconnect && clickconnect != undefined){
                clickconnect.removeAttribute("style", "border: 3px solid #0775E4;");
            }
            item.setAttribute("style", "border: 3px solid #0775E4;");
            clickconnect = item;
        });
    });

    bundleconnect.forEach((item, index) => {
        item.addEventListener("click", function(event){
            if (item != clickstorage && clickstorage != undefined){
                clickstorage.removeAttribute("style", "border: 3px solid #0775E4;");
            }
            item.setAttribute("style", "border: 3px solid #0775E4;");
            clickstorage = item;
        });
    });

    bundlestyle.forEach((item, index) => {
        item.addEventListener("click", function(event){
            if (item != clickstyle && clickstyle != undefined){
                clickstyle.removeAttribute("style", "border: 3px solid #0775E4;");
            }
            item.setAttribute("style", "border: 3px solid #0775E4;");
            clickstyle = item;
        });
    });
}
function createHE(jsArray){
    // 創建基本陣列
    colors = [...new Set(jsArray.map(x => x.color))];
    price = [...new Set(jsArray.map(x => x.price))];
    storage = [...new Set(jsArray.map(x => x.storage))];
    network = [...new Set(jsArray.map(x => x.network))];
    imgs = [...new Set(jsArray.map(x => x.picture))];
    productimgs = [...new Set(jsArray.map(x => x.productimg))];
    price.pop();
    colors.forEach((item, index) => {
        colorsList.push([item, imgs[index]]);
    });
    price.forEach((item, index) => {
        storageList.push([item, storage[index]]);
    });
    price.forEach((item, index) => {
        networkList.push([item, network[index]]);
    });
    styles = [["加上鐫刻", "免費"], ["不加鐫刻", ""]];

    // 抓出 html body
    let body = document.querySelector("body");
    
    // 導覽列
    let navp = document.querySelector(".container > .title > p");
    navp.innerText = `NT$  ${new Intl.NumberFormat().format(price[0])}  起`;

    // 主要內容
    let group = document.createElement("div");
    group.setAttribute("class", "group");
    let left = document.createElement("div");
    left.setAttribute("class", "left col-sm-12 col-lg-6");
    let right = document.createElement("div");
    right.setAttribute("class", "right col-sm-12 col-lg-6");
    
    /// 左
    let leftimg = document.createElement("img");
    leftimg.setAttribute("src", "Hw6_iPadAir/ipad-air-select.jpg");
    leftimg.setAttribute("alt", "All ipadAir color model");

    /// 右
    //// 外觀
    let p1 = document.createElement("p");
    p1.innerText = "全新";
    let h2 = document.createElement("h2");
    h2.innerText = "購買 iPad Air";
    let content = document.createElement("div");
    content.setAttribute("class", "content");
    let p3 = document.createElement("p");
    p3.innerText = "外觀";
    let exteriorp = document.createElement("p");
    colorsList.forEach((item, index) => {
        let block = document.createElement("div");
        block.setAttribute("class", "col-6");
        let bundle = document.createElement("div");
        bundle.setAttribute("class", "bundle h-auto");
        let innerimg = document.createElement("img");
        innerimg.setAttribute("src", `Hw6_iPadAir/${item[1]}`);
        let innerp = document.createElement("p");
        innerp.innerText = item[0];
        bundle.append(innerimg);
        bundle.append(innerp);
        block.append(bundle);
        exteriorp.append(block);
    });
    content.append(p3);
    content.append(exteriorp);
    left.append(leftimg);
    group.append(left);
    right.append(p1);
    right.append(h2);
    right.append(content);
    group.append(right);
    body.append(group);

    //// 儲存裝置
    let contentstorage = document.createElement("div");
    contentstorage.setAttribute("class", "content");
    let p4 = document.createElement("p");
    p4.innerText = "儲存裝置";
    let storagep = document.createElement("p");
    let storagenotice = document.createElement("div");
    storagenotice.setAttribute("class", "storagenotie");
    storagenotice.innerHTML = "<span>提前為日後預留空間。</span>你的 iPad Air 儲存空間愈大， 你就有愈多空間儲存數位內容，滿足今日所需，也滿足未來需求。";
    
    storageList.forEach((item, index) => {
        let block = document.createElement("div");
        block.setAttribute("class", "col-6");
        let bundle = document.createElement("div");
        bundle.setAttribute("class", "bundlestorage");
        let innerp = document.createElement("p");
        innerp.setAttribute("class", "fs-3");
        innerp.innerText = item[1];
        let innerp2 = document.createElement("p");
        innerp2.innerText = `NT$  ${new Intl.NumberFormat().format(item[0])}  起`;
        bundle.append(innerp);
        bundle.append(innerp2);
        block.append(bundle);
        storagep.append(block);
    });
    contentstorage.append(p4);
    contentstorage.append(storagenotice);
    contentstorage.append(storagep);
    right.append(contentstorage);

    //// 連線能力
    let connect = document.createElement("div");
    connect.setAttribute("class", "content");
    let p5 = document.createElement("p");
    p5.innerText = "連線能力";
    let connectp = document.createElement("p");
    let connectnotice = document.createElement("div");
    connectnotice.setAttribute("class", "connectnotice");
    connectnotice.innerHTML = "<span>兩種快速的方式，讓你時時保持聯繫。</span>每部 iPad Air 都可連接到 Wi-Fi 網路。Wi-Fi + 行動網路機型則讓你在無法使用 Wi-Fi 時，也能連上線。";
    networkList.forEach((item, index) => {
        let block = document.createElement("div");
        block.setAttribute("class", "col-6");
        let bundle = document.createElement("div");
        bundle.setAttribute("class", "bundleconnect");
        let innerp = document.createElement("p");
        innerp.setAttribute("class", "fs-3");
        innerp.innerText = item[1];
        let innerp2 = document.createElement("p");
        innerp2.innerText = `NT$  ${new Intl.NumberFormat().format(item[0])}  起`;
        bundle.append(innerp);
        bundle.append(innerp2);
        block.append(bundle);
        connectp.append(block);
    });
    connect.append(p5);
    connect.append(connectnotice);
    connect.append(connectp);
    right.append(connect);

    //// 讓你的裝置更具風格
    let style = document.createElement("div");
    style.setAttribute("class", "content");
    let p6 = document.createElement("p");
    p6.innerText = "讓你的裝置更具風格";
    let stylep = document.createElement("p");
    let stylenotice = document.createElement("div");
    stylenotice.setAttribute("class", "stylenotice");
    stylenotice.innerHTML = "<span>為你的 iPad Air 特製個人特色，免額外付費。</span>表情符號、名稱、暱稱文字與數字可混搭鐫刻，打造專屬於你的 iPad Air。只在 Apple 提供。";
    styles.forEach((item, index) => {
        let block = document.createElement("div");
        block.setAttribute("class", "col-12");
        let bundle = document.createElement("div");
        bundle.setAttribute("class", "bundlestyle");
        let innerp = document.createElement("p");
        innerp.setAttribute("class", "fs-3");
        innerp.innerText = item[0];
        let innerp2 = document.createElement("p");
        innerp2.innerText = item[1];
        bundle.append(innerp);
        bundle.append(innerp2);
        block.append(bundle);
        stylep.append(block);
    });
    style.append(p6);
    style.append(stylenotice);
    style.append(stylep);
    right.append(style);
}