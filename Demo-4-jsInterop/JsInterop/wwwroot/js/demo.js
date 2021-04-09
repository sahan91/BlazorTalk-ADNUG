
export function enableButtonsDemo(sel, evt, componentInstance) {

    let els = document.querySelectorAll(sel);

    for (let i = 0, l = els.length; i < l; i++) {
        els[i].addEventListener(evt, function () {
            let num = this.id;
            const reason = prompt("Why did you click the button?", "No reason")
            componentInstance.invokeMethodAsync('HandleClick', num, reason);
        });
    }
}