// JavaScript source code
onmessage = function (event) {
    var num = event.data;
    var result = 0;
    for (var i = 0; i < num; i++) {
        result += i;
    }

    result = (1+num)* num / 2;
    postMessage(result);//���ݽ�����ظ����߳�
}