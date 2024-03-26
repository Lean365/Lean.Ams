import { HtmlNode, HtmlNodeModel } from "@logicflow/core";

class ButtonNode extends HtmlNode {
  setHtml(rootEl) {
    const { properties } = this.props.model;

    const el = document.createElement("div");
    el.className = "uml-wrapper";
    const html = `
      <div style='background:#5498c1;color: #FFFFFF;border-radius: 5px;text-align:center;white-space:nowrap;padding: 5px'>
        <div style='font-size: 16px;font-weight: bold;'>${properties.name}</div>
        <div style='font-size: 14px;'>${properties.title}</div>
      </div>
    `;
    el.innerHTML = html;
    rootEl.innerHTML = "";
    rootEl.appendChild(el);
    window.stop = (ev) => {
      ev.stopPropagation();
    };
  }
}

class ButtonNodeModel extends HtmlNodeModel {
  // constructor(props) {
  //   super(props)
  //   this.width = props.width
  // }
  setAttributes() {
    if (this.properties.name && this.properties.title) {
      this.width = this.properties.title.length * 17
    } else {
      this.width = this.properties.name.length * 15
    }

    this.height = 50;
    this.text.editable = false;
  }
}
export default {
  type: "button-node",
  view: ButtonNode,
  model: ButtonNodeModel
};

