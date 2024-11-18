<template>
  <div>
    <el-steps :active="active" finish-status="success" style="margin-bottom: 20px">
      <el-step title="第一步"></el-step>
      <el-step title="第二步"></el-step>
    </el-steps>

    <div v-if="active === 0">
      <el-form ref="form" :model="form" label-width="80px" :rules="rules">
        <el-form-item label="数据库名" prop="databaseName">
          <el-select v-model="form.databaseName" placeholder="请选择数据库名">
            <el-option label="数据库1" value="database1"></el-option>
            <el-option label="数据库2" value="database2"></el-option>
            <el-option label="数据库3" value="database3"></el-option>
          </el-select>
        </el-form-item>
        <el-form-item label="表名" prop="tableName">
          <el-input v-model="form.tableName" show-word-limit maxlength="40"></el-input>
        </el-form-item>
        <el-form-item label="表描述" prop="tableDescription">
          <el-input v-model="form.tableDescription" show-word-limit maxlength="40"></el-input>
        </el-form-item>
        <el-form-item>
          <el-button type="primary" @click="nextStep" :disabled="!isFormValid">下一步</el-button>
        </el-form-item>
      </el-form>
    </div>

    <div v-if="active === 1">
      <el-row :gutter="10">
        <el-col :span="1.5">
          <el-button class="btn-add" v-hasPermi="['fico:accountingcorp:add']" plain icon="plus"
            @click="newColumn">新建列</el-button>
          <el-button class="btn-export" v-hasPermi="['fico:accountingcorp:add']" plain @click="newPrimaryKey"
            :disabled="tableData.some(row => row.columnName=='ID') ">新建主键列</el-button>
          <el-button class="btn-import" v-hasPermi="['fico:accountingcorp:add']" plain @click="newBaseColumn"
            :disabled="tableData.some(row => row.columnName=='Create_by') ">新建基础列</el-button>
          <el-button class="btn-deletebatch" :disabled="single" v-hasPermi="['pp:defectassyma:delete']" plain
            icon="delete" @click="handleDelete">
            {{ $t('btn.delete') }}
          </el-button>
          <!-- <el-button class="btn-delete" v-hasPermi="['fico:accountingcorp:add']" plain
            @click="deleteSelectedColumn">删除选中列</el-button> -->
        </el-col>
      </el-row>
      <br>

      <el-table :data="tableData" border height="600px" header-cell-class-name="el-table-header-cell" draggable
        highlight-current-row>
        <el-table-column type="selection" width="55"></el-table-column>
        <el-table-column label="ID" prop="id" width="50"></el-table-column>
        <el-table-column label="字段名称" prop="columnName" width="300" align="center">
          <template #default="scope">
            <el-input v-model="scope.row.columnName" v-show="scope.row.editing" show-word-limit
              maxlength="40"></el-input>
            <span v-show="!scope.row.editing">{{ scope.row.columnName }}</span>
          </template>
        </el-table-column>
        <el-table-column label="描述" prop="description" width="300" align="center">
          <template #default="scope">
            <el-input v-model="scope.row.description" v-show="scope.row.editing" show-word-limit
              maxlength="40"></el-input>
            <span v-show="!scope.row.editing">{{ scope.row.description }}</span>
          </template>
        </el-table-column>
        <el-table-column label="主键" prop="primaryKey" width="80" align="center">
          <template #default="scope">
            <el-checkbox v-model="scope.row.primaryKey"></el-checkbox>
          </template>
        </el-table-column>
        <el-table-column label="自增" prop="autoIncrement" width="80" align="center">
          <template #default="scope">
            <el-checkbox v-model="scope.row.autoIncrement"></el-checkbox>
          </template>
        </el-table-column>
        <el-table-column label="类型" prop="type" width="130" align="center">
          <template #default="scope">
            <el-select v-model="scope.row.type" v-show="scope.row.editing" style="width: 100px;"
              @change="checkDataType">
              <el-option label="bigint" value="bigint" />
              <el-option label="bigint" value="bigint" />
              <el-option label="char" value="char" />
              <el-option label="datetime" value="datetime" />
              <el-option label="decimal" value="decimal" />
              <el-option label="int" value="int" />
              <el-option label="nvarchar" value="nvarchar" />
              <el-option label="nvarchar(max)" value="nvarchar(max)" />
              <el-option label="text" value="text" />
              <el-option label="uniqueidentifier" value="uniqueidentifier" />
              <el-option label="varchar" value="varchar" />
              <el-option label="varchar(max)" value="varchar(max)" />

            </el-select>
            <span v-show="!scope.row.editing">{{ scope.row.type }}</span>
          </template>
        </el-table-column>
        <el-table-column label="必填" prop="required" width="80" align="center">
          <template #default="scope">
            <el-checkbox v-model="scope.row.required"></el-checkbox>
          </template>
        </el-table-column>
        <el-table-column label="长度" prop="length" width="130" align="center">
          <template #default="scope">
            <el-input-number v-model="scope.row.length" :min="0" v-show="scope.row.editing"
              style="width: 100px;"></el-input-number>
            <span v-show="!scope.row.editing">{{ scope.row.length }}</span>
          </template>
        </el-table-column>
        <el-table-column label="精度" prop="precision" width="130" align="center">
          <template #default="scope">
            <el-input-number v-model="scope.row.precision" :min="0" v-show="scope.row.editing"
              style="width: 100px;"></el-input-number>
            <span v-show="!scope.row.editing">{{ scope.row.precision }}</span>
          </template>
        </el-table-column>
        <el-table-column :label="$t('btn.operation')" width="160" align="center">
          <template #default="scope">

            <el-button-group>
              <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')"
                v-hasPermi="['pp:defectassyma:delete']" @click="handleDelete(scope.$index)"
                v-if="scope.row.columnName !== 'ID'&& scope.row.columnName !== 'Remark'&& scope.row.columnName !== 'Ref01'"></el-button>
            </el-button-group>

          </template>
        </el-table-column>

      </el-table>
      <el-button type="primary" @click="submitForm" :disabled="tableData.length < 2">提交</el-button>
    </div>
  </div>
</template>

<script setup>
  import '@/assets/styles/btn-custom.scss'

  const active = ref(0)
  const form = reactive({
    databaseName: 's',
    tableName: 's',
    tableDescription: 's'
  })
  const rules = {
    databaseName: [{ required: false, message: '请选择数据库名' }],
    tableName: [{ required: false, message: '请输入表名' }],
    tableDescription: [{ required: false, message: '请输入表描述' }]
  }
  const isFormValid = computed(() => {
    return form.databaseName && form.tableName && form.tableDescription
  })

  const tableData = reactive([
    {
      id: 1,
      columnName: 'ID',
      description: 'ID',
      primaryKey: true,
      autoIncrement: true,
      type: 'int',
      required: true,
      length: 0,
      precision: 0,
      creator: '',
      createTime: '',
      editing: true
    }
  ])

  const nextStep = () => {
    active.value = 1
  }

  const newColumn = () => {
    tableData.push({
      id: tableData.length + 1,
      columnName: 'ColumnName' + tableData.length,
      description: '表字段描述' + tableData.length,
      primaryKey: false,
      autoIncrement: false,
      type: 'varchar',
      required: false,
      length: 10,
      precision: 2,
      creator: '',
      createTime: '',
      editing: true
    })
  }

  const newPrimaryKey = () => {
    tableData.push({
      id: tableData.length + 1,
      columnName: 'ID',
      description: 'ID',
      primaryKey: true,
      autoIncrement: true,
      type: 'bigint',
      required: true,
      length: 0,
      precision: 0,
      creator: '系统',
      createTime: new Date(),
      editing: true
    })
  }

  const newBaseColumn = () => {
    addBaseColumn()
  }
  //const colIndex = tableData.length
  // 增加通用基础列
  function addBaseColumn() {
    const fileds = [
      {
        id: tableData.length + 1,
        columnName: 'Remark',
        description: '备注',
        primaryKey: false,
        autoIncrement: false,
        type: 'nvarchar',
        required: false,
        length: 500,
        precision: 0,
        creator: '系统',
        createTime: new Date(),
        editing: true
      },
      {
        id: tableData.length + 1,
        columnName: 'Ref01',
        description: '预留A',
        primaryKey: false,
        autoIncrement: false,
        type: 'varchar',
        required: false,
        length: 1,
        precision: 0,
        creator: '系统',
        createTime: new Date(),
        editing: true
      },
      {
        id: tableData.length + 1,
        columnName: 'Ref02',
        description: '',
        primaryKey: false,
        autoIncrement: false,
        type: 'varchar',
        required: false,
        length: 8,
        precision: 0,
        creator: '系统',
        createTime: new Date(),
        editing: true
      },
      {
        id: tableData.length + 1,
        columnName: 'Ref03',
        description: '',
        primaryKey: false,
        autoIncrement: false,
        type: 'varchar',
        required: false,
        length: 30,
        precision: 0,
        creator: '系统',
        createTime: new Date(),
        editing: true
      },
      {
        id: tableData.length + 1,
        columnName: 'Ref04',
        description: '',
        primaryKey: false,
        autoIncrement: false,
        type: 'decimal',
        required: true,
        length: 18,
        precision: 5,
        creator: '系统',
        createTime: new Date(),
        editing: true
      },
      {
        id: tableData.length + 1,
        columnName: 'Ref05',
        description: '',
        primaryKey: false,
        autoIncrement: false,
        type: 'decimal',
        required: true,
        length: 18,
        precision: 5,
        creator: '系统',
        createTime: new Date(),
        editing: true
      },
      {
        id: tableData.length + 1,
        columnName: 'Ref06',
        description: '',
        primaryKey: false,
        autoIncrement: false,
        type: 'decimal',
        required: true,
        length: 18,
        precision: 5,
        creator: '系统',
        createTime: new Date(),
        editing: true
      },
      {
        id: tableData.length + 1,
        columnName: 'Udf01',
        description: '',
        primaryKey: false,
        autoIncrement: false,
        type: 'varchar',
        required: false,
        length: 100,
        precision: 0,
        creator: '系统',
        createTime: new Date(),
        editing: true
      },
      {
        id: tableData.length + 1,
        columnName: 'Udf02',
        description: '',
        primaryKey: false,
        autoIncrement: false,
        type: 'varchar',
        required: false,
        length: 100,
        precision: 0,
        creator: '系统',
        createTime: new Date(),
        editing: true
      }, {
        id: tableData.length + 1,
        columnName: 'Udf03',
        description: '',
        primaryKey: false,
        autoIncrement: false,
        type: 'varchar',
        required: false,
        length: 200,
        precision: 0,
        creator: '系统',
        createTime: new Date(),
        editing: true
      }, {
        id: tableData.length + 1,
        columnName: 'Udf04',
        description: '',
        primaryKey: false,
        autoIncrement: false,
        type: 'varchar',
        required: false,
        length: 300,
        precision: 0,
        creator: '系统',
        createTime: new Date(),
        editing: true
      }, {
        id: tableData.length + 1,
        columnName: 'Udf05',
        description: '',
        primaryKey: false,
        autoIncrement: false,
        type: 'varchar',
        required: false,
        length: 400,
        precision: 0,
        creator: '系统',
        createTime: new Date(),
        editing: true
      }, {
        id: tableData.length + 1,
        columnName: 'Udf06',
        description: '',
        primaryKey: false,
        autoIncrement: false,
        type: 'varchar',
        required: false,
        length: 500,
        precision: 0,
        creator: '系统',
        createTime: new Date(),
        editing: true
      }, {
        id: tableData.length + 1,
        columnName: 'Udf51',
        description: '',
        primaryKey: false,
        autoIncrement: false,
        type: 'int',
        required: true,
        length: 0,
        precision: 0,
        creator: '系统',
        createTime: new Date(),
        editing: true
      },
      {
        id: tableData.length + 1,
        columnName: 'Udf52',
        description: '',
        primaryKey: false,
        autoIncrement: false,
        type: 'int',
        required: true,
        length: 0,
        precision: 0,
        creator: '系统',
        createTime: new Date(),
        editing: true
      }, {
        id: tableData.length + 1,
        columnName: 'Udf53',
        description: '',
        primaryKey: false,
        autoIncrement: false,
        type: 'int',
        required: true,
        length: 0,
        precision: 0,
        creator: '系统',
        createTime: new Date(),
        editing: true
      }, {
        id: tableData.length + 1,
        columnName: 'Udf54',
        description: '',
        primaryKey: false,
        autoIncrement: false,
        type: 'decimal',
        required: true,
        length: 18,
        precision: 5,
        creator: '系统',
        createTime: new Date(),
        editing: true
      }, {
        id: tableData.length + 1,
        columnName: 'Udf55',
        description: '',
        primaryKey: false,
        autoIncrement: false,
        type: 'decimal',
        required: true,
        length: 18,
        precision: 5,
        creator: '系统',
        createTime: new Date(),
        editing: true
      }, {
        id: tableData.length + 1,
        columnName: 'Udf56',
        description: '',
        primaryKey: false,
        autoIncrement: false,
        type: 'decimal',
        required: true,
        length: 18,
        precision: 5,
        creator: '系统',
        createTime: new Date(),
        editing: true
      },
      {
        id: tableData.length + 1,
        columnName: 'Is_deleted',
        description: '',
        primaryKey: false,
        autoIncrement: false,
        type: 'int',
        required: true,
        length: 0,
        precision: 0,
        creator: '系统',
        createTime: new Date(),
        editing: true
      },
      {
        id: tableData.length + 1,
        columnName: 'Create_by',
        description: '',
        primaryKey: false,
        autoIncrement: false,
        type: 'varchar',
        required: false,
        length: 64,
        precision: 0,
        creator: '系统',
        createTime: new Date(),
        editing: true
      },
      {
        id: tableData.length + 1,
        columnName: 'Create_time',
        description: '',
        primaryKey: false,
        autoIncrement: false,
        type: 'datetime',
        required: false,
        length: 0,
        precision: 0,
        creator: '系统',
        createTime: new Date(),
        editing: true
      },
      {
        id: tableData.length + 1,
        columnName: 'Update_by',
        description: '',
        primaryKey: false,
        autoIncrement: false,
        type: 'varchar',
        required: false,
        length: 64,
        precision: 0,
        creator: '系统',
        createTime: new Date(),
        editing: true
      },
      {
        id: tableData.length + 1,
        columnName: 'Update_time',
        description: '',
        primaryKey: false,
        autoIncrement: false,
        type: 'datetime',
        required: false,
        length: 0,
        precision: 0,
        creator: '系统',
        createTime: new Date(),
        editing: true
      },
    ];
    tableData.length + 1;
    fileds.forEach((m) => {
      tableData.push({
        id: tableData.length + 1,
        columnName: m.columnName,
        description: m.description,
        primaryKey: m.primaryKey,
        autoIncrement: m.autoIncrement,
        type: m.type,
        required: m.required,
        length: m.length,
        precision: m.precision,
        creator: m.creator,
        createTime: m.createTime,
        editing: m.editing,

      });
      tableData.length + 1;
    });
  }
  const checkDataType = (value) => {
    if (value === 'number') {
      required = true; // Set required to true if number is selected
    } else {
      required = false; // Set required to false for other types
    }
  };
  // const handleDelete = () => {
  //   tableData.splice(tableData.findIndex(item => item.editing), 1)
  // }

  const editColumn = (index) => {
    tableData[index].editing = true
  }

  const saveColumn = (index) => {
    tableData[index].editing = false
  }

  const handleDelete = (index) => {
    tableData.splice(tableData.findIndex(item => item.editing), 1)
  }

  const submitForm = () => {
    console.log(tableData)
  }  
</script>

<style scoped>
  .custom-select {
    width: 150px;
    /* 设置选择框的宽度 */
    font-size: 10px;
    /* 设置字体大小 */
  }

  .custom-select .el-select-dropdown {
    font-size: 10px;
    /* 设置下拉菜单的字体大小 */
  }
</style>