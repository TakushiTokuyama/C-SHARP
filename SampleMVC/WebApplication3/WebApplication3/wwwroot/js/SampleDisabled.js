// button
const register = document.getElementById('register');

// Form
const post_register = document.getElementById('post_register');

// 検索条件
const dai = document.getElementById('dai');
const chu = document.getElementById('chu');
const sho = document.getElementById('sho');

// 結果
const daiResult = document.getElementById('daiResult');
const chuResult = document.getElementById('chuResult');
const shoResult = document.getElementById('shoResult');
const setResult = document.getElementById('setResult');

// 初期表示
window.addEventListener('load', (event) => {
    console.log('ページ読み込み');
    resultSetDisabled();
});

// button クリックEvent
register.addEventListener("click", function (event) {
    console.log('登録');

    dai.type = 'hidden';
    chu.type = 'hidden';
    sho.type = 'hidden';

    document.registerForm.appendChild(dai);
    document.registerForm.appendChild(chu);
    document.registerForm.appendChild(sho);

    document.registerForm.submit();
}, false);

// 非活性/活性
function resultSetDisabled() {
    console.log('非活性/活性');
    if (dai.value.length > 0) {
        daiResult.disabled = true;
    } else {
        daiResult.disabled = false;
    }
    if (chu.value.length > 0) {
        chuResult.disabled = true;
    } else {
        chuResult.disabled = false;
    }
    if (sho.value.length > 0) {
        shoResult.disabled = true;
    } else {
        shoResult.disabled = false;
    }
    if (dai.value.length > 0 && chu.value.length > 0 && sho.value.length > 0) {
        setResult.disabled = true;
    } else {
        setResult.disabled = false;
    }
}