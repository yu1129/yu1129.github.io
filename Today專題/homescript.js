let afterward = document.querySelectorAll(".afterward");
let groupcard = document.querySelectorAll(".group-card");
let other_dropdown = document.querySelectorAll(".other-selection-limit .title-icon");
let other_ul = document.querySelectorAll(".other-selection-limit ul");

afterward.forEach((item, index) => {
    item.addEventListener("click", () => {
        groupcard[index].querySelectorAll("div").forEach((item, index) => {
            item.setAttribute("style", "transform: translateX(-200px);");
        })
    })
})
other_dropdown.forEach((item, index) => {
    item.addEventListener("click", ()=>{
        other_ul[index].classList.add("d-block");
    });
})

// function openul(count){
//     other_ul[count].classList.add("d-block");
// }