const { createApp, ref, reactive } = Vue

createApp({
setup() {
    const msg = ref('Hello vue!')
    const className = ref('classtest');
    let btnStatus = ref(true);
    let btn_name = "btn1_controller";
    let count = ref(0);
    function counter(){
        count.value++
    }
    function change_btn1(){
        btnStatus.value = (btnStatus.value==true)?false:true;
    }
    return {
        msg, className, btnStatus, btn_name, change_btn1,counter, count
    }
}
}).mount('#app')

createApp({
    setup() {
        let result_block = ref('result');
        let clickStatus = ref(true);
        // let p_btn = clickStatus.value;
        let btnName = ref('btnclass');
        function changeStatus(e){
            clickStatus.value = (clickStatus.value==false)?true:false;
        }
        return {
            result_block, btnName, clickStatus, changeStatus
        }
    }
    }).mount('#app2')