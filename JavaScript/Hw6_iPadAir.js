const url = "https://raw.githubusercontent.com/yu1129/data_respository/main/Hw6_ipadAir.json?token=GHSAT0AAAAAACCMVQSSPTGEF6CKR7HJQBIOZCZXIZQ";

let xhr = new XMLHttpRequest();
let ipadArray;
let colors, price, storage, network, imgs, productimgs;
let colorsList = [];
let storageList = [];
let networkList = []
let styles, spendstorage, spendconnect;

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
    let spendshow = document.querySelector(".title > p");
    let contentp1 = document.querySelectorAll(".content > p:first-of-type");
    let contentp2 = document.querySelectorAll(".content > p:last-of-type");
    let clickcolor, clickstorage, clickconnect, clickstyle;
    
    bundles.forEach((item, index) => {
        item.addEventListener("click", function(event){
            if (item != clickcolor && clickcolor != undefined){
                clickcolor.removeAttribute("style", "border: 3px solid #0775E4;");
            }
            item.setAttribute("style", "border: 3px solid #0775E4;");
            left.innerHTML = "";
            left.innerHTML = `<img src = 'Hw6_iPadAir/${productimgs[index]}' alt = ${colors[index]}>`;
            left.querySelector("img").animate(tdSpinning, tdTiming);
            clickcolor = item;
            openandclose(item, 0);
        });
    });

    function openandclose(item, index){
        if (item != null){
            contentp2[index].style.display = "none";
            contentp1[index].innerHTML = item.querySelector("p").innerText;
            let span = document.createElement("span");
            span.innerText = "更改";
            span.setAttribute("class", "text-primary fs-6");
            contentp1[index].append(span);
            contentp1[index].setAttribute("class", "fs-1 fw-3 d-flex justify-content-between align-item-center");
            contentp1[index].setAttribute("style", "cursor: pointer");
        }
    }

    contentp1.forEach((item, index) => {
        item.addEventListener("click", function(){
            contentp2[index].style.display = "flex";
            contentp1[index].removeAttribute("class", "fs-1 fw-3");
            contentp1[index].removeAttribute("style", "cursor: pointer");
            if (index == 0){
                contentp1[index].innerText = "外觀";
            }
            else if (index == 1){
                contentp1[index].innerText = "儲存裝置";
            }
            else if (index == 2){
                contentp1[index].innerText = "連線能力";
            }
            else {
                contentp1[index].innerText = "讓你的裝置更具風格";
            }
        });
    });

    bundlestorage.forEach((item, index) => {
        item.addEventListener("click", function(event){
            if (item != clickstorage && clickstorage != undefined){
                clickstorage.removeAttribute("style", "border: 3px solid #0775E4;");
            }
            item.setAttribute("style", "border: 3px solid #0775E4;");
            clickstorage = item;
            spendstorage = clickstorage.querySelector("p:last-of-type").innerText;
            bundleconnect[0].querySelector("p:last-of-type").innerText = `NT$  ${new Intl.NumberFormat().format(spendstorage.substring(4, spendstorage.length - 2).replace(",", ""))}  起`;
            bundleconnect[1].querySelector("p:last-of-type").innerText = `NT$  ${new Intl.NumberFormat().format(price[price.indexOf(parseInt(spendstorage.substring(4, spendstorage.length - 2).replace(",", ""))) + 1])}  起`;
            openandclose(item, 1);
            if (clickconnect == null){
                spendshow.innerText = `NT$  ${new Intl.NumberFormat().format(parseInt(spendstorage.substring(4, spendstorage.length - 2).replace(",", "")))}  起`;
            }
            else{
                calculate();
            }
        });
    });

    bundleconnect.forEach((item, index) => {
        item.addEventListener("click", function(event){
            if (item != clickconnect && clickconnect != undefined){
                clickconnect.removeAttribute("style", "border: 3px solid #0775E4;");
            }
            item.setAttribute("style", "border: 3px solid #0775E4;");
            clickconnect = item;
            spendconnect = clickconnect.querySelector("p:last-of-type").innerText;
            spendshow.innerText = `NT$  ${new Intl.NumberFormat().format(spendconnect.substring(4, spendconnect.length - 2).replace(",", ""))}  起`;
            openandclose(item, 2);
        });
    });

    function calculate(){
        spendconnect = clickconnect.querySelector("p:last-of-type").innerText;
        spendshow.innerText = `NT$  ${new Intl.NumberFormat().format(parseInt(spendconnect.substring(4, spendconnect.length - 2).replace(",", "")))}  起`;
    }

    bundlestyle.forEach((item, index) => {
        item.addEventListener("click", function(event){
            if (item != clickstyle && clickstyle != undefined){
                clickstyle.removeAttribute("style", "border: 3px solid #0775E4;");
            }
            item.setAttribute("style", "border: 3px solid #0775E4;");
            clickstyle = item;
            openandclose(item, 3);
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
    p3.setAttribute("class", "d-flex");
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
    storagep.append(storagenotice);
    storageList.forEach((item, index) => {
        if (index == 2){
            return;
        }
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
    connectp.append(connectnotice);
    networkList.forEach((item, index) => {
        if (index == 2){
            return;
        }
        let block = document.createElement("div");
        block.setAttribute("class", "col-6");
        let bundle = document.createElement("div");
        bundle.setAttribute("class", "bundleconnect");
        let innerp = document.createElement("p");
        innerp.setAttribute("class", "fs-4");
        innerp.innerText = item[1];
        let innerp2 = document.createElement("p");
        innerp2.innerText = `NT$  ${new Intl.NumberFormat().format(item[0])}  起`;
        bundle.append(innerp);
        bundle.append(innerp2);
        block.append(bundle);
        connectp.append(block);
    });
    connect.append(p5);
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
    stylep.append(stylenotice);
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
    style.append(stylep);
    right.append(style);
}

const tdSpinning = [
    { transform: 'rotate(0) scale(0)' },
    { transform: 'rotate(360deg) scale(1)' }
];

const tdTiming = {
    duration: 2000,
    iterations: 1,
}
