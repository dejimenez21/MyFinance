import React, { useEffect, useState } from "react";
import { Button, Dropdown, Form, Input, Modal } from "semantic-ui-react";
import { Expense } from "../../app/models/expenses/expense";
import currencyOptions from "../../app/models/currencyOptions";
import { useStore } from "../../app/stores/store";
import PaymentAccountDropdownItem from "../liquidity/PaymentAccountDropdownItem";
import { observer } from "mobx-react-lite";

interface Props {
  modalOpen: boolean;
  handleClose: () => void;
  handleSubmit: (expense: Expense) => void;
}

const ExpenseForm = ({ modalOpen, handleClose, handleSubmit }: Props) => {
  const { accountStore, expenseGroupStore, expenseStore } = useStore();
  const { liquidAccounts, loadLiquidAccounts } = accountStore;
  const { expenseGroups, loadExpenseGroups } =
    expenseGroupStore;
  const { loadCategories, categories } = expenseStore;

  useEffect(() => {
    loadLiquidAccounts(true);
    loadExpenseGroups();
    loadCategories();
  }, [loadLiquidAccounts, loadExpenseGroups, loadCategories]);

  const [expenseData, setExpenseData] = useState<Expense>({
    id: "",
    description: "",
    amount: { value: 0, currency: "DOP" },
    date: new Date().toISOString().split("T")[0],
    accountId: "",
    groupId: undefined,
    category: ""
  });

  const accountsOptions = () =>
    liquidAccounts.map((account) => {
      return {
        key: account.id,
        value: account.id,
        text: account.alias,
        name: "accountId",
        content: <PaymentAccountDropdownItem account={account} />,
      };
    });

  const groupsOptions = () => {
    return expenseGroups.map((group) => {
      return {
        key: group.id,
        value: group.id,
        text: group.name,
      };
    });
  };

  const cateogoriesOptions = () => {
    return categories.map((category) => {
      return {
        key: category.name,
        value: category.name,
        text: category.displayName,
      };
    });
  };

  const handleChange = (_: React.SyntheticEvent<HTMLElement>, data: any) => {
    const { name, value } = data;

    if (name === "amount.value") {
      setExpenseData({
        ...expenseData,
        amount: { ...expenseData.amount, value: parseFloat(value) },
      });
    } else if (name === "amount.currency") {
      setExpenseData({
        ...expenseData,
        amount: { ...expenseData.amount, currency: value },
      });
    } else {
      setExpenseData({
        ...expenseData,
        [name]: value,
      });
    }
  };

  return (
    <Modal open={modalOpen} onClose={handleClose} closeIcon>
      <Modal.Header>Add Expense</Modal.Header>
      <Modal.Content>
        <Form>
          <Form.Field
            control={Input}
            label="Description"
            name="description"
            placeholder="Description"
            value={expenseData.description}
            onChange={handleChange}
          />
          <Form.Field
            control={Input}
            label="Amount"
            name="amount.value"
            placeholder="Amount"
            type="number"
            value={expenseData.amount.value}
            onChange={handleChange}
          />
          <Form.Select
            label="Currency"
            name="amount.currency"
            options={currencyOptions}
            value={expenseData.amount.currency}
            onChange={handleChange}
          />
          <Form.Field
            control={Input}
            label="Date"
            name="date"
            placeholder="Date"
            type="date"
            value={expenseData.date}
            onChange={handleChange}
          />
          <Form.Field>
            <label>Payment Account</label>
            <Dropdown
              name="accountId"
              selection
              direction="right"
              value={expenseData.accountId}
              onChange={handleChange}
              options={accountsOptions()}
            />
          </Form.Field>
          {/* TODO: Make this a search select */}
          <Form.Select
            label="Category"
            name="category"
            options={cateogoriesOptions()}
            value={expenseData.category}
            onChange={handleChange}
            placeholder="Select Category"
          />
          {/* TODO: Change this field for better experience. Show the option of No Group. */}
          <Form.Select
            label="Group"
            name="groupId"
            options={groupsOptions()}
            value={expenseData.groupId}
            onChange={handleChange}
            placeholder="Select Expense Group"
          />
          <Button
            type="submit"
            color="teal"
            content="Submit"
            onClick={() => handleSubmit(expenseData)}
          />
        </Form>
      </Modal.Content>
    </Modal>
  );
};

export default observer(ExpenseForm);
