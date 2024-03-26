<template>
  <div class="container" ref="container"></div>
  <BpmnNodePanel :lf="lf"></BpmnNodePanel>
  <div class="node-item ">
    <div class="node-item-icon bpmn-save" @click="saveNode()">
    </div>
    <span class="node-label">保存</span>
    <div class="node-item-icon bpmn-clear" @click="cleanNode()"></div>
    <span class="node-label">清空</span>
    <div class="node-item-icon bpmn-loading" @click="reloadNode()"></div>
    <span class="node-label">加载</span>
    <div class="node-item-icon bpmn-delete" @click="deleteNode()"></div>
    <span class="node-label">删除</span>
    <div class="node-item-icon bpmn-custom" @click="getList()"></div>
    <span class="node-label">获取定义流程</span>
    <div class="node-item-icon bpmn-examples" @click="flowRun()"></div>
    <span class="node-label">工作流实例</span>
  </div>
</template>
<script>
  import LogicFlow from '@logicflow/core'
  import '@logicflow/core/dist/style/index.css'
  import { BpmnElement, BpmnXmlAdapter, Menu, Control, DndPanel } from '@logicflow/extension'
  import '@logicflow/extension/lib/style/index.css'
  import BpmnNodePanel from "./BpmnNodePanel.vue"
  import { addFlow, infoFlow, deleteFlow, getDeployList, flowRun } from "./server"
  import { addFlowable, addProp, getTypeNameByTag, setValueByTag } from './xml'

  export default {
    data() {
      return {
        lf: void 0,
        xmlData: void 0,
        definitionsId: void 0,
        processId: void 0,
      }
    },
    components: { BpmnNodePanel },
    created() { },
    mounted() {
      this.loadFlow()
    },
    methods: {
      loadFlow() {
        LogicFlow.use(BpmnElement)
        LogicFlow.use(BpmnXmlAdapter)
        LogicFlow.use(Menu)
        LogicFlow.use(Control)
        LogicFlow.use(DndPanel)
        //初始化
        this.lf = new LogicFlow({
          container: this.$refs.container,
          stopScrollGraph: true,
          stopZoomGraph: true,
          grid: true,
          keyboard: {
            enabled: true,
          },
        });
        // this.lf.setDefaultEdgeType('bezier')
        this.lf.render();
      },
      // 保存
      saveNode() {
        // 获取xml数据
        this.xmlData = this.lf.getGraphData();

        // 添加flowable扩展
        this.xmlData = addFlowable(this.xmlData)

        // 判断是否为文档编辑
        if (this.processId) {
          // 修改为原流程id
          this.xmlData = setValueByTag(this.xmlData, 'bpmn:definitions', 'id', this.definitionsId)
          this.xmlData = setValueByTag(this.xmlData, 'bpmn:process', 'id', this.processId)
        } else {
          // 添加节点用户 个人assignee  候选人candidateUsers 候选组候选人candidateGroups 动态设置${employee}
          // this.xmlData = addProp(this.xmlData, 'bpmn:startEvent', 'flowable:candidateUsers', 'zhao,qian,sun')
          this.xmlData = addProp(this.xmlData, 'bpmn:userTask', 'flowable:candidateUsers', 'li,zhou,wang')
        }

        const data = {
          name: '测试流程',
          xml: this.xmlData
        }

        // 请求后台接口（添加工作流）
        addFlow(data)
          .then(res => {
            console.log(res)
          })
          .catch(err => {
            console.log(err)
          })
      },
      // 清除
      cleanNode() {
        this.lf.clearData()
      },
      // 重新加载
      reloadNode() {
        // 查询数据
        const data = {
          id: 'ff292b5d-4193-11ee-8e48-502b73dc5fce',
          name: '测试流程'
        }
        infoFlow(data)
          .then(res => {
            if (res.result) {
              // 获取processId
              const definitionsNodes = getTypeNameByTag(res.result, 'bpmn:definitions')
              const processNodes = getTypeNameByTag(res.result, 'bpmn:process')
              this.definitionsId = definitionsNodes.id
              this.processId = processNodes.id
              // 渲染数据
              this.lf.render(res.result);
            }
            console.log(res)
          })
          .catch(err => {
            console.log(err)
          })
      },
      // 删除数据
      deleteNode() {
        // 查询数据
        const data = {
          id: ''
        }
        deleteFlow(data)
          .then(res => {
            console.log(res)
          })
          .catch(err => {
            console.log(err)
          })
      },
      // 获取数据
      getList() {
        getDeployList()
          .then(res => {
            console.log(res)
          })
          .catch(err => {
            console.log(err)
          })
      },
      // 流程实例
      flowRun() {
        flowRun()
          .then(res => {
            console.log(res)
          })
          .catch(err => {
            console.log(err)
          })
      },
    },
  }
</script>
<style scoped>
  .container {
    width: 100%;
    height: 100%;

  }



  .node-item {
    position: absolute;
    top: 100px;
    right: 10px;
    width: 50px;
    padding: 10px;
    background-color: white;
    box-shadow: 0 0 10px 1px rgb(228, 224, 219);
    border-radius: 6px;
    text-align: center;
    z-index: 101;
  }

  .node-item-icon {
    width: 32px;
    height: 32px;

    background-size: cover;
  }

  .node-label {
    font-size: 12px;
    margin-top: 5px;
    user-select: none;
  }

  .bpmn-save {
    background: url(data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAPZJREFUOE+tkzEOglAMhv+Cq5wBDwBuzt5EGR00wQuAi3HRRHGXo3AEoweQIxBdlcojeQThqRjp1Nf0ff3bpmTs+wcwj1EyZnbK78InjISv33UncY+x8MkIbK4mX6cnkjEjsFyAlgBWIDJFMQZHEtIUsMmAvgQIuIR8BXS31pw0WlcBuUKi8CvA2PUHRYsaJtV5KQFg5AOqGcGsxtQA5W918BXwrvIHNQVAu2s9udsmAuT6XwDowHzwo9ZnGaiTHifTY6QEtKIgRTr81AIzx7fZOWxHASP+eQZCXa5AHGF+TDv7AoL5zxb87Da8DLZosr5Sjidu4Qm/Y4w7BSI70wAAAABJRU5ErkJggg==)center center no-repeat;
    cursor: default;
  }

  .bpmn-clear {
    background: url(data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAStJREFUOE+Nk1FugzAQRGfNb6l6g9gnCZykgHKPJveogJ4k9CQ4N6hKf+ON1gnIUKzAH7Ln7e7smLDh66u0IMY7E32b+vcYSmiDHrZKebzHoFMIeQrw1YFmAijOzedfN/6vAvriTUNdM1MPbV+9Hgn8MQp0Pcw0/wALgQWgg2rtrh7KqAfLdlf8sWDY0MxZB5cqbRgothjLQCkjzgD94SWDIw2XdOKBrA6EbBXI6HQz5DOALdNzILAM+gLYQrGFUxkx78NzXQ9mAkh1cnSOtD/N7oEAFLB3Ljl5wAbzllzLikvJgweESdtioNxhlxjT/tg7YDF7uPsYcAzUfYRH8gDSCrxjIJN9RzcgFR6JjL4F8UWM8u0uskHAlMinj2nqEADRtQFBs0tymV/Obn4ChoCgRNfoAAAAAElFTkSuQmCC)center center no-repeat;
    cursor: default;
  }

  .bpmn-loading {
    background: url(data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABEAAAAQCAYAAADwMZRfAAAAAXNSR0IArs4c6QAAAVdJREFUOE+VlE1SwkAQhd8LHEDRA8ACqjyF5CSQJXgI8RDAEjxJ4BRWkQU5gIUeAKatnp+QxACaVTLT883r7tchGp675Uc3Mu0xKCOAXUByGyZ8P7z0Z/UjLC/oYUp7RWDo1v1h+64wv1aDFRB7u7T3NgzYCI/J9+TJKQBwVodXx8JbUFVA7hdZahWUNi+mKq1UlUVE/DnpbyzkYb4bC7lSBV/Tftx0uJ62Uy35YTroWUhnsdsr2fDYK6dwDdZZ7lYQjlWNh2QCyvowGSS3VIT9x2U2NIJU02fx8U9IaISW4Ay5UdAmhZoSDbYsE/9S1CaYrYlrr3QNT/G1wuqFLdPyRgRO0Wmj8ZUW3ypuZ57NQG82796ixRW7X6nNL9eWfVLY2jtRTRSRibrxou3rSsqBzQMYhs9FUiQx5IiUXL1VmeIAs2MQ4Rmi0+x+BQLmFGzD0GlqoQk/XuLN/C4DhSAAAAAASUVORK5CYII=)center center no-repeat;
    cursor: default;
  }

  .bpmn-delete {
    background: url(data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAUxJREFUOE/Vk7FKA0EQhmd22TWkECwss7kUkrsuhQ9gr4hokVax8RUs5CIqltqJiMTadxDuLe4CKZJLKWhjkezt7cgFEzjNJQYrB5aFmfk/ZmdnEAosrIjDXIjzwOsNe9/TcZa+o2TbAvSBaCpARN+Nde0HIFSyxQCquQBCgwi6CPAx8VvEGhAFuTzGAgydkgMA2VnavN4wyD0hq8aLdWseKXRKW1k8E2f3FJBVwqz167E+CpU8FUI+Jqkpo6U9Nx7dRlV5+ZbqqzUUzTFgkDwVAqKq7ADDXTR2lRDv3FhvRmrlFc3Is1zsLAYo+Qwcz8YAhiduXx9HShIavf4HgHhBkzT/NWCJHnSU7BLH7XETAR/cgW5ESr6j0Ru/60FFXnDL7w3YMuN0UI/1daTEDZeJb0Zif+E3zp3Ery2dOUiYpu2pGLFwP4jofAL4BBoWAl/sELLLAAAAAElFTkSuQmCC
) center center no-repeat;
    cursor: default;
  }

  .bpmn-examples {
    background: url(data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAWhJREFUOE99k79Ow0AMxj+n6hsgsaYbO+y5ICZeou0AMwMTAuJU6sYLMKWIZ2BDXJBY+wrQGTEwIBZoj/guf6qQiycnZ/9sf+cjVJaztq7BFDGv6v9djk4mAOUSR/bcJYfiAZjAYNQJ0cwgJEWMFAhhzJSQc1YkKigeWVgVZMz0X3GiTJIQp4syLhLAm62s2CVoViBIR1KlPYqqu5MxiJIi1CZkxcEdYFaQKsCiBm634YqtYPBsRzFInQYVxOnQneziwlKD0EJiZgdoZo+gOO69gdbhFsDONK4BT1f7CILbHtg7VHrsBxgOkG9OvAAafEMl937A43wXw58zfwf0hSiZNwC3DyJOiphzaN4DYdYzwicUn8o1irJyPY05CEPzUQ/gVwoRyoVobWIEBBfA+qEH8AqVHlSARn0HbL59BH2zg/j8o+lAXqEYYWy12KwvEQxe/B2YZdmB1aB6jS6+ejCyC14bAofXyz/Z5ZmME6bWGAAAAABJRU5ErkJggg==
) center center no-repeat;
    cursor: default;
  }


  .bpmn-custom {
    background: url(data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAK9JREFUOE/NksENgkAQRf+nBznbidgJ3iTBGow1SII36UTtxDP2wDcjroaEZTfBg3ucmbydzH9sT6Xgeem2orWmZtg31UDJ7cNhtwKYDwHjMz1A3KTFsXGAtt7loM4DgGfmXwCzbzAnBV+EsfVXznPe24NxhIvRdR91mYm4UFgviupq9SiRwoCASPazQTogI7E38QjdvxvEmOg5VJSJbgOBS1NcwiEBfnmDgEhTR3wC74fX1eyu+BEAAAAASUVORK5CYII=
) center center no-repeat;
    cursor: default;
  }
</style>