
export function enableSimple(sel, evt, componentInstance) {

    let els = document.querySelectorAll(sel);

    for (var i = 0, l = els.length; i < l; i++) {
        els[i].addEventListener(evt, function () {
            alert(`clicked: ${this.id}`);

            const reason = prompt("Why did you click the button?", "No reason")
            componentInstance.HandleClick(i, reason);
        });
    }
}